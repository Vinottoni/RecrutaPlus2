using Safety.Application.ViewModels;
using Safety.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Safety.Domain.Interfaces.Services
{
    public interface ICargoService: IService<Cargo>
    {
        Task<Cargo> GetByIdAsync(int id);
        //Task<Office> GetByIdRelatedAsync(int id);
        Task<IEnumerable<Cargo>> GetByFilterAsync(CargoFilter filter = null);
        //Task<IEnumerable<Office>> GetByFilterRelatedAsync(OfficeFilter filter = null);
        Task<IEnumerable<Cargo>> GetByPageAsync(int skip, int take, Expression<Func<Cargo, bool>> predicate = null);
        //Task<IEnumerable<Office>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Office, bool>> predicate = null);
        Task<IEnumerable<Cargo>> GetByTakeLastAsync(int takeLast, Expression<Func<Cargo, bool>> predicate = null);
        //Task<IEnumerable<Office>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Office, bool>> predicate = null);
    }
}
