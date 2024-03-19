using Safety.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Domain.Interfaces.Repositories
{
    public interface IAppLoggerRepository : IRepositoryAsync<AppLogger>
    {
        Task<AppLogger> GetByIdAsync(int id);
    }
}
