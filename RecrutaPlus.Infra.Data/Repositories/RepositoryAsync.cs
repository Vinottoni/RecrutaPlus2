using Microsoft.EntityFrameworkCore;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces.Repositories;
using RecrutaPlus.Domain.Interfaces.UnitOfWork;
using RecrutaPlus.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecrutaPlus.Infra.Data.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : Entity
    {
        protected readonly AppDbContext _dbContext;

        public RepositoryAsync(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTrackingWithIdentityResolution().CountAsync(predicate);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTrackingWithIdentityResolution().Where(predicate).ToListAsync();
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTrackingWithIdentityResolution().AnyAsync(predicate);
        }

        public virtual async Task<int> MaxAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTrackingWithIdentityResolution().CountAsync(predicate);
        }
    }
}
