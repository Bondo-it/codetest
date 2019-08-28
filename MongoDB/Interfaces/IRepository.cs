using codetest.Models.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace codetest.MongoDB.Interfaces
{
    public interface IRepository<T>
        where T : IEntity
    {
        Task Add(T entity);
        void AddSync(T entity);

        Task AddMany(ICollection<T> entities);
        void AddManySync(ICollection<T> entities);

        Task BulkInsert(ICollection<T> entities);
        void BulkInsertSync(ICollection<T> entities);

        Task<long> Count(Expression<Func<T, bool>> filter);
        long CountSync(Expression<Func<T, bool>> filter);

        Task Delete(T entity);
        void DeleteSync(T entity);

        Task Delete(Expression<Func<T, bool>> filter);
        void DeleteSync(Expression<Func<T, bool>> filter);

        Task<ICollection<T>> GetByExpression(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null);

        ICollection<T> GetByExpressionSync(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null);

        Task<ICollection<T>> GetAll(SortDefinition<T> sort = null, ProjectionDefinition<T> projection = null);

        ICollection<T> GetAllSync(SortDefinition<T> sort = null, ProjectionDefinition<T> projection = null);

        Task<ICollection<T>> GetByPageAndQuantity(
            int page,
            int quantity,
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null);

        ICollection<T> GetByPageAndQuantitySync(
            int page,
            int quantity,
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null);

        Task<T> GetSingleByExpression(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1);

        T GetSingleByExpressionSync(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1);

        bool AnySync(
            Expression<Func<T, bool>> filter,
            SortDefinition<T> sort = null,
            ProjectionDefinition<T> projection = null,
            int index = 1);

        void ReplaceOneSync(object id, T newValue);
    }
}