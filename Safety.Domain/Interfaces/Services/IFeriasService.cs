using Safety.Application.ViewModels;
using Safety.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Safety.Domain.Interfaces.Services
{
    public interface IFeriasService : IService<Ferias>
    {
        Task<Ferias> GetByIdAsync(int id);
        Task<Ferias> GetByIdRelatedAsync(int id);
        Task<IEnumerable<Ferias>> GetByFilterAsync(FeriasFilter filter = null);
        Task<IEnumerable<Ferias>> GetByFilterRelatedAsync(FeriasFilter filter = null);
        Task<IEnumerable<Ferias>> GetByPageAsync(int skip, int take, Expression<Func<Ferias, bool>> predicate = null);
        Task<IEnumerable<Ferias>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Ferias, bool>> predicate = null);
        Task<IEnumerable<Ferias>> GetByTakeLastAsync(int takeLast, Expression<Func<Ferias, bool>> predicate = null);
        Task<IEnumerable<Ferias>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Ferias, bool>> predicate = null);
        Task<IEnumerable<Ferias>> GetByQueryRelatedAsync(Expression<Func<Ferias, bool>> predicate = null);
    }
}
