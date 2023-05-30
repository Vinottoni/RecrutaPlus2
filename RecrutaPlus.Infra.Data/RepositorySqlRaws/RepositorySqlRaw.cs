using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces.RepositorySqlRaws;
using RecrutaPlus.Infra.Data.Context;

namespace RecrutaPlus.Infra.Data.RepositorySqlRaws
{
    public class RepositorySqlRaw<T> : IRepositorySqlRaw<T> where T : Entity
    {
        private readonly AppSqlRawDbContext _appSqlRawDbContext;

        public RepositorySqlRaw(AppSqlRawDbContext appSqlRawDbContext)
        {
            _appSqlRawDbContext = appSqlRawDbContext;
        }
    }
}
