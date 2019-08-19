using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using codetest.Models.Interfaces;
using codetest.MongoDB.Interfaces;
using MongoDB.Driver;
using Serilog;

namespace codetest.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected IDbBuilder DbBuilder { get; }

        protected IMongoCollection<T> MongoCollection { get; set; }

        protected IMongoDatabase MongoDatabase { get; set; }

        public BaseRepository(IDbBuilder builder)
        {
            DbBuilder = builder;
            Initialize();
        }

        protected void Initialize()
        {
            GetDatabase();
            GetCollection();
            if (MongoCollection == null) return;
            Log.Debug("Creating mongo index");
            CreateIndex();
        }

        protected void GetDatabase()
        {
            var client = new MongoClient(DbBuilder.GetConnectionString());
            MongoDatabase = client.GetDatabase(DbBuilder.GetDatabaseName());
        }

        protected void GetCollection()
        {
            var type = typeof(T);
            if (MongoCollection != null) return;
            Log.Debug($"Getting mongocollection {typeof(T)}");
            MongoCollection = MongoDatabase.GetCollection<T>(type.Name);
        }

        protected virtual void CreateIndex()
        {

            try
            {
                var indexDefinition = Builders<T>.IndexKeys.Combine(
                    Builders<T>.IndexKeys.Descending(x => x.Id),
                    Builders<T>.IndexKeys.Descending(x => x.Name),
                    Builders<T>.IndexKeys.Descending(x => x.UserName),
                    Builders<T>.IndexKeys.Descending(x => x.Email),
                    Builders<T>.IndexKeys.Descending(x => x.PhoneNumber),
                    Builders<T>.IndexKeys.Descending(x => x.CreatedAt),
                    Builders<T>.IndexKeys.Descending(x => x.ModifiedAt)
                );

                MongoCollection.Indexes.CreateOne(indexDefinition);
            }
            catch (Exception exception)
            {
                Log.Error($"Error creating index {typeof(T)}");
                Log.Error(exception.StackTrace);
            }
        }

        public void AddSync(T entity)
        {
            var now = System.DateTime.Now;
            entity.AddedAt = now;
            entity.ModifiedAt = now;
            entity.CreatedAt = now;

            MongoCollection.InsertOne(entity);
        }

        public async Task Add(T entity)
        {
            var now = System.DateTime.Now;
            entity.AddedAt = now;
            entity.ModifiedAt = now;
            entity.CreatedAt = now;

            await MongoCollection.InsertOneAsync(entity);
        }

        public async Task AddMany(ICollection<T> entities)
        {
            var now = System.DateTime.Now;

            foreach (var entity in entities)
            {
                entity.AddedAt = now;
                entity.ModifiedAt = now;
                entity.CreatedAt = now;
            }

            await MongoCollection.InsertManyAsync(entities);
        }

        public void AddManySync(ICollection<T> entities)
        {
            var now = System.DateTime.Now;

            foreach (var entity in entities)
            {
                entity.AddedAt = now;
                entity.ModifiedAt = now;
                entity.CreatedAt = now;
            }

            MongoCollection.InsertMany(entities);
        }

        public async Task BulkInsert(ICollection<T> entities)
        {
            var now = System.DateTime.Now;

            foreach (var entity in entities)
            {
                entity.ModifiedAt = now;
            }

            var stores = new List<WriteModel<T>>();

            stores.AddRange(entities.Select(x => new InsertOneModel<T>(x)));

            await MongoCollection.BulkWriteAsync(stores);
        }

        public void BulkInsertSync(ICollection<T> entities)
        {
            var now = System.DateTime.Now;

            foreach (var entity in entities)
            {
                entity.ModifiedAt = now;
            }

            var stores = new List<WriteModel<T>>();

            stores.AddRange(entities.Select(x => new InsertOneModel<T>(x)));

            MongoCollection.BulkWrite(stores);
        }

        public async Task<long> Count(Expression<Func<T, bool>> filter)
        {
            return await MongoCollection.CountDocumentsAsync(filter);
        }

        public long CountSync(Expression<Func<T, bool>> filter)
        {
            return MongoCollection.CountDocuments(filter);
        }

        public async Task Delete(T entity)
        {
            await MongoCollection.DeleteOneAsync(Builders<T>.Filter.Eq(e => e.Id, entity.Id));
        }

        public async Task ReplaceOne(T entity, T newValue)
        {
            try
            {
                var update = Builders<T>.Update
                            .Set(x => x.ModifiedAt, DateTime.UtcNow)
                            .Set(x => x.Name, newValue.Name)
                            .Set(x => x.UserName, newValue.UserName)
                            .Set(x => x.PhoneNumber, newValue.PhoneNumber)
                            .Set(x => x.Email, newValue.Email)
                            .Set(x => x.Address, newValue.Address);

                await MongoCollection.UpdateOneAsync(FilterId(entity.Id), update);
            }
            catch (Exception exception)
            {
                Log.Error($"Error creating index {typeof(T)}");
                Log.Error(exception.StackTrace);
            }
        }

        public async Task ReplaceOne(Expression<Func<T, bool>> filter, T newValue)
        {
            var now = System.DateTime.Now;
            newValue.ModifiedAt = now;

            try
            {
                var update = Builders<T>.Update
                            .Set(x => x.ModifiedAt, DateTime.UtcNow)
                            .Set(x => x.Name, newValue.Name)
                            .Set(x => x.UserName, newValue.UserName)
                            .Set(x => x.PhoneNumber, newValue.PhoneNumber)
                            .Set(x => x.Email, newValue.Email)
                            .Set(x => x.Address, newValue.Address);

                await MongoCollection.UpdateOneAsync(filter, update);
            }
            catch (Exception exception)
            {
                Log.Error($"Error creating index {typeof(T)}");
                Log.Error(exception.StackTrace);
            }
        }

        public void ReplaceOneSync(object id, T newValue)
        {
            var now = System.DateTime.Now;
            newValue.ModifiedAt = now;

            try
            {
                var update = Builders<T>.Update
                            .Set(x => x.ModifiedAt, DateTime.UtcNow)
                            .Set(x => x.Name, newValue.Name)
                            .Set(x => x.UserName, newValue.UserName)
                            .Set(x => x.PhoneNumber, newValue.PhoneNumber)
                            .Set(x => x.Email, newValue.Email)
                            .Set(x => x.Address, newValue.Address);

                MongoCollection.UpdateOne(FilterId(id), update);
            }
            catch (Exception exception)
            {
                Log.Error($"Error creating index {typeof(T)}");
                Log.Error(exception.StackTrace);
            }
        }

        public void ReplaceOneSync(Expression<Func<T, bool>> filter, T newValue)
        {
            var now = System.DateTime.Now;
            newValue.ModifiedAt = now;

            try
            {
                var update = Builders<T>.Update
                            .Set(x => x.ModifiedAt, DateTime.UtcNow)
                            .Set(x => x.Name, newValue.Name)
                            .Set(x => x.UserName, newValue.UserName)
                            .Set(x => x.PhoneNumber, newValue.PhoneNumber)
                            .Set(x => x.Email, newValue.Email)
                            .Set(x => x.Address, newValue.Address);

                MongoCollection.UpdateOne(filter, update);
            }
            catch (Exception exception)
            {
                Log.Error($"Error creating index {typeof(T)}");
                Log.Error(exception.StackTrace);
            }
        }

        private static FilterDefinition<T> FilterId(object key)
        {
            return Builders<T>.Filter.Eq("Id", key);
        }

        public void DeleteSync(T entity)
        {
            MongoCollection.DeleteOne(Builders<T>.Filter.Eq(e => e.Id, entity.Id));
        }

        public async Task Delete(Expression<Func<T, bool>> filter)
        {
            await MongoCollection.DeleteOneAsync(filter);
        }

        public void DeleteSync(Expression<Func<T, bool>> filter)
        {
            MongoCollection.DeleteOne(filter);
        }

        public ICollection<T> GetByExpressionSync(Expression<Func<T, bool>> filter, SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return findFluent.ToList();
        }

        public async Task<ICollection<T>> GetByExpression(Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null, ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return await findFluent.ToListAsync();
        }

        public async Task<ICollection<T>> GetAll(SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(_ => true, sort, projection);
            return await findFluent.ToListAsync();
        }

        public ICollection<T> GetAllSync(SortDefinition<T> sort = null, ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(_ => true, sort, projection);
            return findFluent.ToList();
        }

        public async Task<ICollection<T>> GetByPageAndQuantity(
            int page,
            int quantity,
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return await findFluent.Limit(quantity).Skip((page - 1) * quantity).ToListAsync();
        }

        public ICollection<T> GetByPageAndQuantitySync(
            int page,
            int quantity,
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return findFluent.Limit(quantity).Skip((page - 1) * quantity).ToList();
        }

        public async Task<T> GetSingleByExpression(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return await findFluent.Limit(1).Skip(index - 1).FirstOrDefaultAsync();
        }

        public T GetSingleByExpressionSync(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return findFluent.Limit(1).Skip(index - 1).FirstOrDefault();
        }

        public async Task<bool> Any(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1)
        {
            var findFluent = BuildFindFluent(filter, sort, projection);
            return await findFluent.AnyAsync();
        }

        public bool AnySync(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1)
        {
            var test = filter.Compile();
            var findFluent = BuildFindFluent(filter, sort, projection);
            return findFluent.Any();
        }

        public IEnumerable<T> QueryDb(Func<T, bool> filter)
        {
            var retult = MongoCollection.AsQueryable()
                .Where(filter);

            return retult.Distinct();
        }

        protected IFindFluent<T, T> BuildFindFluent(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null)
        {
            var fluent = MongoCollection.Find(filter);
            if (projection != null)
            {
                fluent.Options.Projection = Builders<T>.Projection.Combine(projection);
            }

            if (sort != null)
            {
                fluent.Sort(sort);
            }

            return fluent;
        }
    }
}