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
    public class FeriasService : Service<Ferias>, IFeriasService
    {
        private readonly IFeriasRepository _feriasRepository;
        private readonly IAppLogger _logger;


        public FeriasService(IFeriasRepository parametroRepository, IAppLogger logger)
            : base(parametroRepository)
        {
            _feriasRepository = parametroRepository;
            _logger = logger;
        }

        public override ServiceResult Add(Ferias entity)
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

            _logger.LogInformation(FeriasConst.LOG_TABLE_ADD, DateTime.Now, entity.GuidStamp, entity.FeriasId, entity);

            return serviceResult;
        }

        public override ServiceResult Update(Ferias entity)
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

            _logger.LogInformation(FeriasConst.LOG_TABLE_UPDATE, DateTime.Now, entity.GuidStamp, entity.FeriasId, entity);

            return serviceResult;
        }

        public override ServiceResult Delete(Ferias entity)
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

            _logger.LogInformation(FeriasConst.LOG_TABLE_REMOVE, DateTime.Now, entity.GuidStamp, entity.FeriasId, entity);

            return serviceResult;
        }
        public async Task<Ferias> GetByIdAsync(int id)
        {
            return await _feriasRepository.GetByIdAsync(id);
        }
        public async Task<Ferias> GetByIdRelatedAsync(int id)
        {
            return await _feriasRepository.GetByIdRelatedAsync(id);
        }

        public async Task<IEnumerable<Ferias>> GetByPageAsync(int skip, int take, Expression<Func<Ferias, bool>> predicate = null)
        {
            return await _feriasRepository.GetByPageAsync(skip, take, predicate);
        }

        public async Task<IEnumerable<Ferias>> GetByTakeLastAsync(int takeLast, Expression<Func<Ferias, bool>> predicate = null)
        {
            return await _feriasRepository.GetByTakeLastAsync(takeLast, predicate);
        }

        public async Task<IEnumerable<Ferias>> GetByQueryRelatedAsync(Expression<Func<Ferias, bool>> predicate = null)
        {
            return await _feriasRepository.GetByQueryRelatedAsync(predicate);
        }

        public async Task<IEnumerable<Ferias>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Ferias, bool>> predicate = null)
        {
            return await _feriasRepository.GetByPageRelatedAsync(skip, take, predicate);
        }

        public async Task<IEnumerable<Ferias>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Ferias, bool>> predicate = null)
        {
            return await _feriasRepository.GetByTakeLastRelatedAsync(takeLast, predicate);
        }

        public async Task<IEnumerable<Ferias>> GetByFilterRelatedAsync(FeriasFilter filter = null)
        {
            return await _feriasRepository.GetByFilterRelatedAsync(filter);
        }

        public async Task<IEnumerable<Ferias>> GetByFilterAsync(FeriasFilter filter = null)
        {
            return await _feriasRepository.GetByFilterAsync(filter);
        }
    }
}
