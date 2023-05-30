using RecrutaPlus.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate);
        ServiceResult Add(T entity);
        ServiceResult Update(T entity);
        ServiceResult Delete(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> MaxAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
