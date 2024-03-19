using Safety.Application.ViewModels;
using Safety.Domain.Constants;
using Safety.Domain.Entities;
using Safety.Domain.Interfaces.Repositories;
using Safety.Domain.Interfaces.Services;
using Safety.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Domain.Services
{
    public class CargoService : Service<Cargo>, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IAppLogger _logger;


        public CargoService(ICargoRepository parametroRepository, IAppLogger logger)
            : base(parametroRepository)
        {
            _cargoRepository = parametroRepository;
            _logger = logger;
        }

        public override ServiceResult Add(Cargo entity)
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

            _logger.LogInformation(CargoConst.LOG_TABLE_ADD, DateTime.Now, entity.GuidStamp, entity.CargoId, entity);

            return serviceResult;
        }

        public override ServiceResult Update(Cargo entity)
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

            _logger.LogInformation(CargoConst.LOG_TABLE_UPDATE, DateTime.Now, entity.GuidStamp, entity.CargoId, entity);

            return serviceResult;
        }

        public override ServiceResult Delete(Cargo entity)
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

            _logger.LogInformation(CargoConst.LOG_TABLE_REMOVE, DateTime.Now, entity.GuidStamp, entity.CargoId, entity);

            return serviceResult;
        }
        public async Task<Cargo> GetByIdAsync(int id)
        {
            return await _cargoRepository.GetByIdAsync(id);
        }
        //public async Task<Office> GetByIdRelatedAsync(int id)
        //{
        //    return await _officeRepository.GetByIdRelatedAsync(id);
        //}
        public async Task<IEnumerable<Cargo>> GetByFilterAsync(CargoFilter filter = null)
        {
            return await _cargoRepository.GetByFilterAsync(filter);
        }

        public async Task<IEnumerable<Cargo>> GetByPageAsync(int skip, int take, Expression<Func<Cargo, bool>> predicate = null)
        {
            return await _cargoRepository.GetByPageAsync(skip, take, predicate);
        }

        public async Task<IEnumerable<Cargo>> GetByTakeLastAsync(int takeLast, Expression<Func<Cargo, bool>> predicate = null)
        {
            return await _cargoRepository.GetByTakeLastAsync(takeLast, predicate);
        }

        //public async Task<IEnumerable<Office>> GetByQueryRelatedAsync(Expression<Func<Office, bool>> predicate = null)
        //{
        //    return await _officeRepository.GetByQueryRelatedAsync(predicate);
        //}

        //public async Task<IEnumerable<Office>> GetByFilterRelatedAsync(OfficeFilter filter = null)
        //{
        //    return await _officeRepository.GetByFilterRelatedAsync(filter);
        //}

        //public async Task<IEnumerable<Office>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Office, bool>> predicate = null)
        //{
        //    return await _officeRepository.GetByPageRelatedAsync(skip, take, predicate);
        //}

        //public async Task<IEnumerable<Office>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Office, bool>> predicate = null)
        //{
        //    return await _officeRepository.GetByTakeLastRelatedAsync(takeLast, predicate);
        //}
    }
}
