using codetest.Models;

namespace codetest.MongoDB.Interfaces
{
    public interface IBaseContext
    {
        IRepository<T> ResolveRepository<T>()
            where T : User;
    }
}