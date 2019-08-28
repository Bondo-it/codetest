using codetest.Models;
using codetest.Repositories.Interfaces;
using MongoDB.Driver;

namespace codetest.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase)
        {
            
        }
    }
}
