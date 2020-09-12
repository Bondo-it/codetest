using DataComponent.Repositories.Interfaces;
using DomainModels.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace DataComponent.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(IMongoDatabase mongoDatabase, ILogger<BaseRepository<User>> logger) : base(mongoDatabase, logger)
		{

		}
	}
}
