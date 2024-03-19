using Safety.Domain.Entities;
using Safety.Domain.Interfaces.RepositorySqlRaws;
using Safety.Infra.Data.Context;

namespace Safety.Infra.Data.RepositorySqlRaws
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
