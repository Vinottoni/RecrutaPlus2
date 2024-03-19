using Safety.Domain.Entities;
using Safety.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Safety.Domain.Interfaces.Repositories
{
    public interface IRepositoryAsync<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> MaxAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}
