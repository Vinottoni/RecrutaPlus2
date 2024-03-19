using Microsoft.EntityFrameworkCore;
using Safety.Domain.Entities;
using Safety.Domain.Interfaces.Repositories;
using Safety.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Infra.Data.Repositories
{
    public class AppLoggerRepository : RepositoryAsync<AppLogger>, IAppLoggerRepository
    {
        public AppLoggerRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<AppLogger> GetByIdAsync(int id)
        {
            return await _dbContext.AppLoggers.AsNoTrackingWithIdentityResolution().SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
