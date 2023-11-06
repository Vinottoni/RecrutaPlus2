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
    public class FeriasRepository : RepositoryAsync<Ferias>, IFeriasRepository
    {
        public FeriasRepository(AppDbContext dbContext) : base(dbContext) 
        { 

        }
        public async Task<Ferias> GetByIdAsync(int id)
        {
            return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.FeriasId == id);
        }

        public async Task<IEnumerable<Ferias>> GetByFilterAsync(FeriasFilter filter = null)
        {
            var _query = _dbContext.Ferias.AsNoTrackingWithIdentityResolution();

            //if (filter?.FuncionarioId != null) { _query = _query.Where(w => w.FuncionarioId == filter.FuncionarioId.GetValueOrDefault()); }
            if (filter?.FeriasId != null) { _query = _query.Where(w => w.FeriasId == filter.FeriasId); }

            return await _query.ToListAsync();
        }

        public async Task<IEnumerable<Ferias>> GetByFilterRelatedAsync(FeriasFilter filter = null)
        {
            var _query = _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario).AsQueryable();

            //if (filter?.FuncionarioId != null) { _query = _query.Where(w => w.FuncionarioId == filter.FuncionarioId.GetValueOrDefault()); }
            if (filter?.FeriasId != null) { _query = _query.Where(w => w.FeriasId == filter.FeriasId); }

            return await _query.ToListAsync();
        }

        public async Task<Ferias> GetByIdRelatedAsync(int id)
        {
            return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .SingleOrDefaultAsync(s => s.FeriasId == id);
        }

        public async Task<IEnumerable<Ferias>> GetByPageAsync(int skip, int take, Expression<Func<Ferias, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution().OrderBy(o => o.FeriasId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.FeriasId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Ferias>> GetByQueryRelatedAsync(Expression<Func<Ferias, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Funcionario)
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Funcionario)
                    .Where(predicate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Ferias>> GetByTakeLastAsync(int takeLast, Expression<Func<Ferias, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution().OrderBy(o => o.FeriasId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.FeriasId).Take(takeLast).ToListAsync();
            }
        }

        public async Task<IEnumerable<Ferias>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Ferias, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .OrderBy(o => o.FeriasId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .Where(predicate).OrderBy(o => o.FeriasId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Ferias>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Ferias, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .OrderBy(o => o.FeriasId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Ferias.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .Where(predicate).OrderBy(o => o.FeriasId).Take(takeLast).ToListAsync();
            }
        }

    }
}
