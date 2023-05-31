using Microsoft.EntityFrameworkCore;
using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Domain.Interfaces.Repositories;
using RecrutaPlus.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Infra.Data.Repositories
{
    public class FuncionarioRepository : RepositoryAsync<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AppDbContext dbContext) : base(dbContext) 
        { 

        }
        public async Task<Funcionario> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.FuncionarioId == id);
        }

        public async Task<Funcionario> GetByIdRelatedAsync(int id)
        {
            return await _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .SingleOrDefaultAsync(s => s.FuncionarioId == id);
        }

        public async Task<IEnumerable<Funcionario>> GetByFilterAsync(FuncionarioFilter filter = null)
        {
            var _query = _dbContext.Employees.AsNoTrackingWithIdentityResolution();

            if (filter?.FuncionarioId != null) { _query = _query.Where(w => w.FuncionarioId == filter.FuncionarioId.GetValueOrDefault());}
            if (filter?.CargoId != null) { _query = _query.Where(w => w.CargoId == filter.CargoId); }
            if (filter?.Nome != null) { _query = _query.Where(w => w.Nome == filter.Nome); }
            if (filter?.CPF != null) { _query = _query.Where(w => w.CPF == filter.CPF); }
            //if (filter?.Ativo != null) { _query = _query.Where(w => w.Ativo == filter.Ativo); }

            return await _query.ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetByFilterRelatedAsync(FuncionarioFilter filter = null)
        {
            var _query = _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo);

            //if (filter?.FuncionarioId != null) { _query = _query.Where(w => w.FuncionarioId == filter.FuncionarioId.GetValueOrDefault()); }
            //if (filter?.CargoId != null) { _query = _query.Where(w => w.CargoId == filter.CargoId); }
            //if (filter?.Nome != null) { _query = _query.Where(w => w.Nome == filter.Nome); }
            //if (filter?.CPF != null) { _query = _query.Where(w => w.CPF == filter.CPF); }
            //if (filter?.Ativo != null) { _query = _query.Where(w => w.Ativo == filter.Ativo); }

            ////Office
            //if (filter?.CargoFilter?.Nome != null) { _query = _query.Where(w => w.Cargo.Nome == filter.CargoFilter.Nome); }
            //if (filter?.CargoFilter?.Descricao != null) { _query = _query.Where(w => w.Cargo.Descricao == filter.CargoFilter.Descricao); }

            return await _query.ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetByPageAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution().OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByQueryRelatedAsync(Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Cargo)
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Cargo)
                    .Where(predicate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByTakeLastAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution().OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .Where(predicate).OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Employees.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .Where(predicate).OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
        }

    }
}
