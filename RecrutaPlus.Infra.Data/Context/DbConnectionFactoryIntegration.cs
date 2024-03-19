using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Data.Common;
using System.IO;

namespace Safety.Infra.Data.Context
{
    public class DbConnectionFactoryIntegration
    {
        public DbConnectionFactoryIntegration()
        {
            CreateDbConnection();
        }

        public DbConnectionFactoryIntegration(string dbProviderFactoryType, string dbProviderFactoryName, string connectionStringName)
        {
            CreateDbConnection(dbProviderFactoryType, dbProviderFactoryName, connectionStringName);
        }

        public DbProviderFactory GetDbProviderFactory { get; private set; }
        public DbConnection GetDbConnection { get; private set; }

        private void CreateDbConnection(string dbProviderFactoryType, string dbProviderFactoryName, string connectionString)
        {
            if (dbProviderFactoryType == null || dbProviderFactoryName == null || connectionString == null) return;

            try
            {
                //MsSQL
                if (dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMsSQL)
                {
                    DbProviderFactories.RegisterFactory(dbProviderFactoryName, MySqlConnectorFactory.Instance);
                }

                //MySQL
                if (dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMySQL)
                {
                    DbProviderFactories.RegisterFactory(dbProviderFactoryName, SqlClientFactory.Instance);
                }

                GetDbProviderFactory = DbProviderFactories.GetFactory(dbProviderFactoryName);

                GetDbConnection = GetDbProviderFactory.CreateConnection();

                if (GetDbConnection != null)
                    GetDbConnection.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateDbConnection()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();

            string dbProviderFactoryType = configuration.GetSection(AppDataSettingsConfigurationConst.AppSettings)
               .GetValue<string>(AppDataSettingsConfigurationConst.DbProviderFactoryTypeIntegration);

            string connectionString = configuration.GetConnectionString(
               configuration.GetSection(AppDataSettingsConfigurationConst.AppSettings)
               .GetValue<string>(AppDataSettingsConfigurationConst.ConnectionStringDefaultIntegration));

            string dbProviderFactoryName = null;

            //MsSQL
            if (dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMsSQL)
            {
                dbProviderFactoryName = configuration.GetSection(AppDataSettingsConfigurationConst.AppSettings)
                    .GetValue<string>(AppDataSettingsConfigurationConst.DbProviderFactoryNameIntegration);
            }

            //Oracle
            if (dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeOracle)
            {
                dbProviderFactoryName = configuration.GetSection(AppDataSettingsConfigurationConst.AppSettings)
                    .GetValue<string>(AppDataSettingsConfigurationConst.DbProviderFactoryNameIntegration);
            }

            //MySQL
            if (dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMySQL)
            {
                dbProviderFactoryName = configuration.GetSection(AppDataSettingsConfigurationConst.AppSettings)
                    .GetValue<string>(AppDataSettingsConfigurationConst.DbProviderFactoryNameIntegration);
            }

            if (dbProviderFactoryType == null || dbProviderFactoryName == null || connectionString == null) return;

            try
            {
                //MsSQL
                if (dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMsSQL)
                {
                    DbProviderFactories.RegisterFactory(dbProviderFactoryName, MySqlConnectorFactory.Instance);
                }

                //MySQL
                if (dbProviderFactoryType == AppDataSettingsConfigurationConst.DbProviderFactoryTypeMySQL)
                {
                    DbProviderFactories.RegisterFactory(dbProviderFactoryName, SqlClientFactory.Instance);
                }

                GetDbProviderFactory = DbProviderFactories.GetFactory(dbProviderFactoryName);
                GetDbConnection = GetDbProviderFactory.CreateConnection();

                if (GetDbConnection != null)
                    GetDbConnection.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
