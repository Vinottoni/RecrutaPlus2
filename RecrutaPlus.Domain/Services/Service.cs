using Safety.Domain.Entities;
using Safety.Domain.Interfaces.Repositories;
using Safety.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Safety.Domain.Services
{
    public class Service<T> : IService<T> where T : Entity
    {
        private readonly IRepositoryAsync<T> _repository;

        public Service(IRepositoryAsync<T> repository)
        {
            _repository = repository;
        }

        public virtual ServiceResult Add(T entity)
        {
            //await Task.Run(() => _repository.Add(entity));
            //Task.Run(() => _repository.Add(entity)).Wait();

            ServiceResult serviceResult = new ServiceResult();

            _repository.Add(entity);

            return serviceResult;
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.CountAsync(predicate);
        }

        public virtual ServiceResult Delete(T entity)
        {
            ServiceResult serviceResult = new ServiceResult();

            _repository.Delete(entity);

            return serviceResult;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetByQueryAsync(predicate);
        }

        public virtual ServiceResult Update(T entity)
        {
            ServiceResult serviceResult = new ServiceResult();

            _repository.Update(entity);

            return serviceResult;
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public virtual Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return _repository.ExistsAsync(predicate);
        }

        public virtual async Task<int> MaxAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.MaxAsync(predicate);
        }
    }
}
