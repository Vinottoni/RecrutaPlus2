using Microsoft.EntityFrameworkCore;
using Safety.Application.ViewModels;
using Safety.Domain.Entities;
using Safety.Domain.Interfaces.Repositories;
using Safety.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Infra.Data.Repositories
{
    public class LoginRepository : RepositoryAsync<Login>, ILoginRepository
    {
        public LoginRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Login> GetByIdAsync(int id)
        {
            return await _dbContext.Logins.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.UsuarioId == id);
        }

        //public Task<Login> BuscarPorLogin(Login login)
        //{
        //    return _dbContext.Funcionarios.FirstOrDefault(x => x.Login.Username == login.Username);
        //}

        public async Task<Login> GetByIdRelatedAsync(int id)
        {
            return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .SingleOrDefaultAsync(s => s.UsuarioId == id);
        }

        public async Task<IEnumerable<Login>> GetByFilterAsync(LoginFilter filter = null)
        {
            var _query = _dbContext.Logins.AsNoTrackingWithIdentityResolution();

            if (filter?.UsuarioId != null) { _query = _query.Where(w => w.UsuarioId == filter.UsuarioId.GetValueOrDefault()); }
            if (filter?.FuncionarioId != null) { _query = _query.Where(w => w.FuncionarioId == filter.FuncionarioId); }
            if (filter?.Username != null) { _query = _query.Where(w => w.Username == filter.Username); }

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

        public async Task<IEnumerable<Login>> GetByPageAsync(int skip, int take, Expression<Func<Login, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution().OrderBy(o => o.UsuarioId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.UsuarioId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Login>> GetByQueryRelatedAsync(Expression<Func<Login, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Funcionario)
                    .ToListAsync();
            }
            else
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
                    .Include(i => i.Funcionario)
                    .Where(predicate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Login>> GetByTakeLastAsync(int takeLast, Expression<Func<Login, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution().OrderBy(o => o.UsuarioId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution().Where(predicate).OrderBy(o => o.UsuarioId).Take(takeLast).ToListAsync();
            }
        }

        public async Task<IEnumerable<Login>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Login, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .OrderBy(o => o.UsuarioId).Skip(skip).Take(take).ToListAsync();
            }
            else
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .Where(predicate).OrderBy(o => o.UsuarioId).Skip(skip).Take(take).ToListAsync();
            }
        }

        public async Task<IEnumerable<Login>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Login, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .OrderBy(o => o.UsuarioId).Take(takeLast).ToListAsync();
            }
            else
            {
                return await _dbContext.Logins.AsNoTrackingWithIdentityResolution()
                .Include(i => i.Funcionario)
                .Where(predicate).OrderBy(o => o.UsuarioId).Take(takeLast).ToListAsync();
            }
        }

        
    }
}
