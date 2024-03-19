using Safety.Domain.Entities;
using Safety.Domain.Interfaces.Repositories;
using Safety.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Domain.Services
{
    public class AppLoggerService : Service<AppLogger>, IAppLoggerService
    {
        private readonly IAppLoggerRepository _appLoggerRepository;

        public AppLoggerService(IAppLoggerRepository appLoggerRepository)
            : base(appLoggerRepository)
        {
            _appLoggerRepository = appLoggerRepository;
        }
        public async Task<AppLogger> GetByIdAsync(int id)
        {
            return await _appLoggerRepository.GetByIdAsync(id);
        }
    }
}
