using RecrutaPlus.Application.ViewModels;
using RecrutaPlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecrutaPlus.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IRepositoryAsync<Funcionario>
    {
        Task<Funcionario> GetByIdAsync(int id);
        Task<Funcionario> GetByIdRelatedAsync(int id);
        Task<IEnumerable<Funcionario>> GetByFilterAsync(FuncionarioFilter filter = null);
        Task<IEnumerable<Funcionario>> GetByFilterRelatedAsync(FuncionarioFilter filter = null);
        Task<IEnumerable<Funcionario>> GetByPageAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null);
        Task<IEnumerable<Funcionario>> GetByPageRelatedAsync(int skip, int take, Expression<Func<Funcionario, bool>> predicate = null);
        Task<IEnumerable<Funcionario>> GetByTakeLastAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null);
        Task<IEnumerable<Funcionario>> GetByTakeLastRelatedAsync(int takeLast, Expression<Func<Funcionario, bool>> predicate = null);
        Task<IEnumerable<Funcionario>> GetByQueryRelatedAsync(Expression<Func<Funcionario, bool>> predicate = null);
    }
}
