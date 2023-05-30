using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Infra.Data.Context
{
    public class AppSqlRawDbContext
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public AppSqlRawDbContext(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public DbConnection GetDbConnection()
        {
            return _dbConnectionFactory.GetDbConnection;
        }
    }
}
