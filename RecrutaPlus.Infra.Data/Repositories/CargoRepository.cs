using Microsoft.EntityFrameworkCore;
using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces.Repositories;
using RecrutaPlus.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Infra.Data.Repositories
{
    public class CargoRepository : RepositoryAsync<Cargo>, ICargoRepository
    {
        public CargoRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Cargo> GetByIdAsync(int id)
        {
            return await _dbContext.Offices.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.CargoId == id);
        }

        //public async Task<Office> GetByIdRelatedAsync(int id)
        //{
        //    return await _dbContext.Offices.AsNoTrackingWithIdentityResolution()
        //    .Include(i => i.Employee)
        //        .SingleOrDefaultAsync(s => s.usuarioId == id);
        //}

        public async Task<IEnumerable<Cargo>> GetByFilterAsync(CargoFilter filter = null)
        {
            var _query = _dbContext.Offices.AsNoTrackingWithIdentityResolution();

            if (filter?.CargoId != null) { _query = _query.Where(w => w.CargoId == filter.CargoId.GetValueOrDefault()); }
            if (filter?.Nome != null) { _query = _query.Where(w => w.Nome == filter.Nome); }
            if (filter?.Descricao != null) { _query = _query.Where(w => w.Descricao == filter.Descricao); }

            return await _query.ToListAsync();
        }

        //public async Task<IEnumerable<Login>> GetByFilterRelatedAsync(LoginFilter filter = null)
        //{
        //    var _query = _dbContext.Logins.AsNoTrackingWithIdentityResolution()
        //        .Include(i => i.Employee);

        //    if (filter?.usuarioId != null) { _query = _query.Where(w => w.usuarioId == filter.usuarioId.GetValueOrDefault()); }
        //    if (filter?.funcionarioId != null) { _query = _query.Where(w => w.funcionarioId == filter.funcionarioId); }
        //    if (filter?.username != null) { _query = _query.Where(w => w.username == filter.username); }

        //    //Employee

        //    if (filter?.EmployeeFilter.cargoId != null) { _query = _query.Where(w => w.Employee.cargoId == filter.EmployeeFilter.cargoId); }
        //    if (filter?.EmployeeFilter.nome != null) { _query = _query.Where(w => w.Employee.nome == filter.EmployeeFilter.nome); }
        //    if (filter?.EmployeeFilter.rg != null) { _query = _query.Where(w => w.Employee.rg == filter.EmployeeFilter.rg); }
        //    if (filter?.EmployeeFilter.cpf != null) { _query = _query.Where(w => w.Employee.cpf == filter.EmployeeFilter.cpf); }
        //    if (filter?.EmployeeFilter.email != null) { _query = _query.Where(w => w.Employee.email == filter.EmployeeFilter.email); }
        //    if (filter?.EmployeeFilter.telefone != null) { _query = _query.Where(w => w.Employee.telefone == filter.EmployeeFilter.telefone); }
        //    if (filter?.EmployeeFilter.dataNascimento != null) { _query = _query.Where(w => w.Employee.dataNascimento == filter.EmployeeFilter.dataNascimento); }
        //    if (filter?.EmployeeFilter.genero != null) { _query = _query.Where(w => w.Employee.genero == filter.EmployeeFilter.genero); }
        //    if (filter?.EmployeeFilter.cep != null) { _query = _query.Where(w => w.Employee.cep == filter.EmployeeFilter.cep); }
        //    if (filter?.EmployeeFilter.endereco != null) { _query = _query.Where(w => w.Employee.endereco == filter.EmployeeFilter.endereco); }
        //    if (filter?.EmployeeFilter.bairro != null) { _query = _query.Where(w => w.Employee.bairro == filter.EmployeeFilter.bairro); }
        //    if (filter?.EmployeeFilter.educacao != null) { _query = _query.Where(w => w.Employee.educacao == filter.EmployeeFilter.educacao); }
        //    if (filter?.EmployeeFilter.Ativo != null) { _query = _query.Where(w => w.Employee.Ativo == filter.EmployeeFilter.Ativo); }

        //    return await _query.ToListAsync();
        //}

        public async Task<IEnumerable<Cargo>> GetByPageAsync(int skip, int take, Expression<Func<Cargo, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Offices.AsNoTrackingWithIdentityResolution().OrderBy(o => o.CargoId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Offices.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.CargoId).Skip(skip).Take(take).ToListAsync();
            }
        }

        //public async Task<IEnumerable<Login>> GetByQueryRelatedAsync(Expression<Func<Login, bool>> predicate = null)
        //{
        //    if (predicate == null)
        //    {
        //        return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
        //            .Include(i => i.Employee)
        //            .ToListAsync();
        //    }
        //    else
        //    {
        //        return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
        //            .Include(i => i.Employee)
        //            .Where(predicate).ToListAsync();
        //    }
        //}

        public async Task<IEnumerable<Cargo>> GetByTakeLastAsync(int takeLast, Expression<Func<Cargo, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Offices.AsNoTrackingWithIdentityResolution().OrderBy(o => o.CargoId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Offices.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.CargoId).Take(takeLast).ToListAsync();
            }
        }

        //public async Task<IEnumerable<Login>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Login, bool>> predicate = null)
        //{
        //    if (predicate == null)
        //    {
        //        return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
        //        .Include(i => i.Employee)
        //        .OrderBy(o => o.usuarioId).Skip(skip).Take(take).ToListAsync();
        //    }
        //    else
        //    {
        //        return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
        //        .Include(i => i.Employee)
        //        .Where(predicate).OrderBy(o => o.usuarioId).Skip(skip).Take(take).ToListAsync();
        //    }
        //}

        //public async Task<IEnumerable<Login>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Login, bool>> predicate = null)
        //{
        //    if (predicate == null)
        //    {
        //        return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
        //        .Include(i => i.Employee)
        //        .OrderBy(o => o.usuarioId).Take(takeLast).ToListAsync();
        //    }
        //    else
        //    {
        //        return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
        //        .Include(i => i.Employee)
        //        .Where(predicate).OrderBy(o => o.usuarioId).Take(takeLast).ToListAsync();
        //    }
        //}

    }
}
