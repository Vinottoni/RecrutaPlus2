using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.Interfaces.Repositories
{
    public interface ILoginRepository : IRepositoryAsync<Login>
    {
        Task<Login> GetByIdAsync(int id);
        Task<Login> GetByIdRelatedAsync(int id);
        Task<IEnumerable<Login>> GetByFilterAsync(LoginFilter filter = null);
        //Task<IEnumerable<Login>> GetByFilterRelatedAsync(LoginFilter filter = null);
        Task<IEnumerable<Login>> GetByPageAsync(int skip, int take, Expression<Func<Login, bool>> predicate = null);
        Task<IEnumerable<Login>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Login, bool>> predicate = null);
        Task<IEnumerable<Login>> GetByTakeLastAsync(int takeLast, Expression<Func<Login, bool>> predicate = null);
        Task<IEnumerable<Login>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Login, bool>> predicate = null);
        Task<IEnumerable<Login>> GetByQueryRelatedAsync(Expression<Func<Login, bool>> predicate = null);
    }
}
