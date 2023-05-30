namespace RecrutaPlus.Infra.Data
{
    public struct AppDataSettingsConfigurationConst
    {
        //Settings
        public static string AppSettings => "appSettings";

        //DbProviderFactory
        public static string DbProviderFactoryType => "DBProviderFactoryType";
        public static string DbProviderFactoryName => "DBProviderFactoryName";
        public static string ConnectionStringDefault => "ConnectionStringDefault";

        //DbProviderFactory Integration
        public static string DbProviderFactoryTypeIntegration => "DbProviderFactoryTypeIntegration";
        public static string DbProviderFactoryNameIntegration => "DbProviderFactoryNameIntegration";
        public static string ConnectionStringDefaultIntegration => "ConnectionStringDefaultIntegration";

        public static string DbProviderFactoryTypeMsSQL => "MsSQL";
        public static string DbProviderFactoryTypeOracle => "Oracle";
        public static string DbProviderFactoryTypeMySQL => "MySQL";
    }
}