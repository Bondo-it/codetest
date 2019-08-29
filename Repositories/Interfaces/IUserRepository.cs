using codetest.Models;
using codetest.MongoDB.Interfaces;

namespace codetest.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
