using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.Interfaces.Repositories;
using RecrutaPlus.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.Services
{
    public class FuncionarioService : Service<Funcionario>, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IAppLogger _logger;


        public FuncionarioService(IFuncionarioRepository parametroRepository, IAppLogger logger)
            : base(parametroRepository)
        {
            _funcionarioRepository = parametroRepository;
            _logger = logger;
        }

        public override ServiceResult Add(Funcionario entity)
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

            _logger.LogInformation(FuncionarioConst.LOG_TABLE_ADD, DateTime.Now, entity.GuidStamp, entity.FuncionarioId, entity);

            return serviceResult;
        }

        public override ServiceResult Update(Funcionario entity)
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

            _logger.LogInformation(FuncionarioConst.LOG_TABLE_UPDATE, DateTime.Now, entity.GuidStamp, entity.FuncionarioId, entity);

            return serviceResult;
        }

        public override ServiceResult Delete(Funcionario entity)
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

            _logger.LogInformation(FuncionarioConst.LOG_TABLE_REMOVE, DateTime.Now, entity.GuidStamp, entity.FuncionarioId, entity);

            return serviceResult;
        }
        public async Task<Funcionario> GetByIdAsync(int id)
        {
            return await _funcionarioRepository.GetByIdAsync(id);
        }
        public async Task<Funcionario> GetByIdRelatedAsync(int id)
        {
            return await _funcionarioRepository.GetByIdRelatedAsync(id);
        }
        public async Task<IEnumerable<Funcionario>> GetByFilterAsync(FuncionarioFilter filter = null)
        {
            return await _funcionarioRepository.GetByFilterAsync(filter);
        }

        public async Task<IEnumerable<Funcionario>> GetByPageAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null)
        {
            return await _funcionarioRepository.GetByPageAsync(skip, take, predicate);
        }

        public async Task<IEnumerable<Funcionario>> GetByTakeLastAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null)
        {
            return await _funcionarioRepository.GetByTakeLastAsync(takeLast, predicate);
        }

        public async Task<IEnumerable<Funcionario>> GetByQueryRelatedAsync(Expression<Func<Funcionario, bool>> predicate = null)
        {
            return await _funcionarioRepository.GetByQueryRelatedAsync(predicate);
        }

        public async Task<IEnumerable<Funcionario>> GetByFilterRelatedAsync(FuncionarioFilter filter = null)
        {
            return await _funcionarioRepository.GetByFilterRelatedAsync(filter);
        }

        public async Task<IEnumerable<Funcionario>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null)
        {
            return await _funcionarioRepository.GetByPageRelatedAsync(skip, take, predicate);
        }

        public async Task<IEnumerable<Funcionario>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null)
        {
            return await _funcionarioRepository.GetByTakeLastRelatedAsync(takeLast, predicate);
        }
    }
}
