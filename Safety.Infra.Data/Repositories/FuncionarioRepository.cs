﻿using Microsoft.EntityFrameworkCore;
using Safety.Application.ViewModels;
using Safety.Domain.Entities;
using Safety.Domain.Interfaces.Repositories;
using Safety.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Infra.Data.Repositories
{
    public class FuncionarioRepository : RepositoryAsync<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AppDbContext dbContext) : base(dbContext) 
        { 

        }
        public async Task<Funcionario> GetByIdAsync(int id)
        {
            return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.FuncionarioId == id);
        }

        public async Task<Funcionario> GetByIdRelatedAsync(int id)
        {
            return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .Include(i => i.Ferias)
                .SingleOrDefaultAsync(s => s.FuncionarioId == id);
        }

        public async Task<IEnumerable<Funcionario>> GetByFilterAsync(FuncionarioFilter filter = null)
        {
            var _query = _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution();

            if (filter?.FuncionarioId != null) { _query = _query.Where(w => w.FuncionarioId == filter.FuncionarioId.GetValueOrDefault());}
            if (filter?.CargoId != null) { _query = _query.Where(w => w.CargoId == filter.CargoId); }
            if (filter?.Nome != null) { _query = _query.Where(w => EF.Functions.Like(w.Nome, $"%{filter.Nome}")); }
            if (filter?.CPF != null) { _query = _query.Where(w => w.CPF == filter.CPF); }

            return await _query.ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetByFilterRelatedAsync(FuncionarioFilter filter = null)
        {
            var _query = _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo).AsQueryable()
                .Include(i => i.Ferias).AsQueryable();

            if (filter?.FuncionarioId != null) { _query = _query.Where(w => w.FuncionarioId == filter.FuncionarioId.GetValueOrDefault()); }
            if (filter?.CargoId != null) { _query = _query.Where(w => w.CargoId == filter.CargoId); }
            if (filter?.Nome != null) { _query = _query.Where(w => w.Nome == filter.Nome); }
            if (filter?.CPF != null) { _query = _query.Where(w => w.CPF == filter.CPF); }
            if (filter?.Ativo != null) { _query = _query.Where(w => w.Ativo == filter.Ativo); }

            return await _query.ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetByPageAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution().OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByQueryRelatedAsync(Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Cargo)
                    .Include(i => i.Ferias)
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Cargo)
                    .Include(i => i.Ferias)
                    .Where(predicate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByTakeLastAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution().OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .Include(i => i.Ferias)
                .OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .Include(i => i.Ferias)
                .Where(predicate).OrderBy(o => o.FuncionarioId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .Include(i => i.Ferias)
                .OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Funcionarios.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Cargo)
                .Include(i => i.Ferias)
                .Where(predicate).OrderBy(o => o.FuncionarioId).Take(takeLast).ToListAsync();
            }
        }

    }
}
