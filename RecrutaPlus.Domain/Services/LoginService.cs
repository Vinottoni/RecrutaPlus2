using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces.Repositories;
using RecrutaPlus.Domain.Interfaces.Services;
using RecrutaPlus.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.Services
{
    public class LoginService : Service<Login>, ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IAppLogger _logger;


        public LoginService(ILoginRepository parametroRepository, IAppLogger logger)
            : base(parametroRepository)
        {
            _loginRepository = parametroRepository;
            _logger = logger;
        }

        public override ServiceResult Add(Login entity)
        {
            ServiceResult serviceResult = new ServiceResult();

            if (!entity.IsValid())
            {
                foreach (var error in entity.ValidationResult.Errors)
                {
                    serviceResult.AddError(error.PropertyName, error.ErrorMessage);
                }
                return serviceResult;
            }

            if (serviceResult.HasErrors)
            {
                return serviceResult;
            }

            base.Add(entity);

            _logger.LogInformation(LoginConst.LOG_TABLE_ADD, DateTime.Now, entity.GuidStamp, entity.UsuarioId, entity);

            return serviceResult;
        }

        public override ServiceResult Update(Login entity)
        {
            ServiceResult serviceResult = new ServiceResult();

            if (!entity.IsValid())
            {
                foreach (var error in entity.ValidationResult.Errors)
                {
                    serviceResult.AddError(error.PropertyName, error.ErrorMessage);
                }
                return serviceResult;
            }

            if (serviceResult.HasErrors)
            {
                return serviceResult;
            }

            base.Update(entity);

            _logger.LogInformation(LoginConst.LOG_TABLE_UPDATE, DateTime.Now, entity.GuidStamp, entity.UsuarioId, entity);

            return serviceResult;
        }

        public override ServiceResult Delete(Login entity)
        {
            ServiceResult serviceResult = new ServiceResult();

            if (!entity.IsValid())
            {
                foreach (var error in entity.ValidationResult.Errors)
                {
                    serviceResult.AddError(error.PropertyName, error.ErrorMessage);
                }
                return serviceResult;
            }


            if (serviceResult.HasErrors)
            {
                return serviceResult;
            }

            base.Delete(entity);

            _logger.LogInformation(LoginConst.LOG_TABLE_REMOVE, DateTime.Now, entity.GuidStamp, entity.UsuarioId, entity);

            return serviceResult;
        }
        public async Task<Login> GetByIdAsync(int id)
        {
            return await _loginRepository.GetByIdAsync(id);
        }
        public async Task<Login> GetByIdRelatedAsync(int id)
        {
            return await _loginRepository.GetByIdRelatedAsync(id);
        }
        public async Task<IEnumerable<Login>> GetByFilterAsync(LoginFilter filter = null)
        {
            return await _loginRepository.GetByFilterAsync(filter);
        }

        public async Task<IEnumerable<Login>> GetByPageAsync(int skip, int take, Expression<Func<Login, bool>> predicate = null)
        {
            return await _loginRepository.GetByPageAsync(skip, take, predicate);
        }

        public async Task<IEnumerable<Login>> GetByTakeLastAsync(int takeLast, Expression<Func<Login, bool>> predicate = null)
        {
            return await _loginRepository.GetByTakeLastAsync(takeLast, predicate);
        }

        public async Task<IEnumerable<Login>> GetByQueryRelatedAsync(Expression<Func<Login, bool>> predicate = null)
        {
            return await _loginRepository.GetByQueryRelatedAsync(predicate);
        }

        //public async Task<IEnumerable<Login>> GetByFilterRelatedAsync(LoginFilter filter = null)
        //{
        //    return await _loginRepository.GetByFilterRelatedAsync(filter);
        //}

        public async Task<IEnumerable<Login>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Login, bool>> predicate = null)
        {
            return await _loginRepository.GetByPageRelatedAsync(skip, take, predicate);
        }

        public async Task<IEnumerable<Login>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Login, bool>> predicate = null)
        {
            return await _loginRepository.GetByTakeLastRelatedAsync(takeLast, predicate);
        }
    }
}
