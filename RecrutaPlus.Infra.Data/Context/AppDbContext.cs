using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Safety.Domain.Entities;
using Safety.Domain.Interfaces.UnitOfWork;
using Safety.Infra.Data.Mappings.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Infra.Data.Context
{
    public class AppDbContext :DbContext, IUnitOfWork
    {
        private readonly string _dbProviderFactoryType;
        private readonly string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext(string dbProviderFactoryType, string connectionString) 
        { 
            _dbProviderFactoryType = dbProviderFactoryType;
            _connectionString = connectionString;
        }

        public static readonly ILoggerFactory loggerFactoryDatabase = LoggerFactory.Create(builder => { builder.AddDebug(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMsSQL)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            if (_dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMySQL)
            {
                optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
            }
        }

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionBuilder.UseMySql("server=localhost;Port=3306;User Id=root;password=123456;Persist Security Info=True;database=recrutamais2", ServerVersion.AutoDetect("server=localhost;Port=3306;User Id=root;password=123456;Persist Security Info=True;database=recrutamais"));
                return new AppDbContext(optionBuilder.Options);
            }
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<AppLogger> AppLoggers { get; set; }
        public DbSet<Ferias> Ferias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FuncionarioMap());
            builder.ApplyConfiguration(new LoginMap());
            builder.ApplyConfiguration(new CargoMap());
            builder.ApplyConfiguration(new FeriasMap());
        }

    }
}
