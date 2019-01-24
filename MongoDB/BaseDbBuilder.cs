using codetest.Models;
using codetest.MongoDB.Interfaces;

namespace codetest.MongoDB.DbBuilder
{
    public class BaseDbBuilder : IDbBuilder
    {
        readonly string _databaseName;
        readonly string _connectionString;

        public BaseDbBuilder()
        {
            _databaseName = codetest.Startup.Configuration.GetSection("ConnectionStrings")["DatabaseName"];
            _connectionString = codetest.Startup.Configuration.GetSection("ConnectionStrings")["ConnectionString"];
        }

        public virtual string GetDatabaseName()
        {
            return _databaseName;
        }

        public virtual string GetConnectionString()
        {
            return _connectionString;
        }
    }
}