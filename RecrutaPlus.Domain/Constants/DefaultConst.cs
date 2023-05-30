namespace RecrutaPlus.Domain.Constants
{
    public struct DefaultConst
    {
        public static string ADMIN = "Administrador";
        public static string ADMIN_EMAIL = "admin@fatec.sp.gov.br";

        public static string CULTURE_INFO_PTBR = "pt-BR";
        public static string CULTURE_INFO_ENUS = "en-US";

        public static string USER_ANONYMOUS = "Anonymous";

        public const string APPLICATION_JSON = "application/json";

        public const string TEMPDATA_SUCCESSMESSAGE = "SuccessMessage";
        public const string TEMPDATA_ERRORMESSAGE = "ErrorMessage";
        public const string TEMPDATA_SCROLLPOSITION = "ScrollPosition";

        public const string TEMPDATA_FILTERSTATE = "FilterState";
        public const string TEMPDATA_MEMORYCACHE = "MemoryCache";
        public const string TEMPDATA_ENABLED = "Enabled";

        public const string TEMPDATA_REDIRECTTOACTION = "RedirectToAction";

        public const bool FILTER_HASFILTER_DEFAULT = true;
        public const int FILTER_TAKELAST_DEFAULT = 100;
        public const int FILTER_TAKELAST_DEFAULT_ALL = int.MaxValue;

        public const string CONTROLLER_NAME = "Home";

        #region Msg

        public static string MSG_REQUIRED = "Campo obrigatório";

        public static string MSG_SIM = "Sim";

        public static string MSG_NAO = "Não";

        public static string MSG_OK = "OK";

        public static string MSG_VALOR_DUPLICADO = "Valor duplicado. Existe um registro com este valor";

        public static string MSG_TOKEN_CONCORRENCY = "Este registro foi alterado por outro usuário";

        public static string MSG_PROBLEMA_INESPERADO = "Ocorreu um problema inesperado. Entre em contato com administrador";

        public static string MSG_SAVED_SUCCESSFULLY = "Registro salvo com sucesso.";

        public static string MSG_UPDATED_SUCCESSFULLY = "Registro atualizado com sucesso.";

        public static string MSG_DELETED_SUCCESSFULLY = "Registro salvo com sucesso.";

        #endregion

        #region Char


        public const string TOKEN_NAME = "TK";

        public const string PASSWORD_NAME = "PK";

        public const string PATH_PHOTO_DEFAULT = "comp";

        public const string AUTHORIZATION_HEADER_TYPE = "Authorization";

        public const string AUTHENTICATION_HEADER_TYPE = "Bearer";

        public const string CHAR_S = "S";
        public const string CHAR_N = "N";

        public const string CARRIAGE_RETURN = "\r\n";

        public const string CHAR_ASTERISCO = "*";
        public const string CHAR_BARRA = "/";
        public const string CHAR_HIFEN = "-";
        public const string CHAR_BARRA_INVERTIDA = @"\";
        public const string CHAR_TIL = "~";
        public const string CHAR_PORCENTAGEM = "%";
        public const string CHAR_PONTO_VIRGULA = ";";
        public const string CHAR_DOISPONTOS = ":";
        public const string CHAR_ESPACO = " ";
        public const string CHAR_PARENTESE_OPEN = "(";
        public const string CHAR_PARENTESE_CLOSE = ")";
        public const string CHAR_COLCHETE_OPEN = "[";
        public const string CHAR_COLCHETE_CLOSE = "]";
        public const string CHAR_ASPA_SIMPLES = "'";
        public const string CHAR_IGUAL = "=";
        public const string CHAR_MAIOR = ">";
        public const string CHAR_MENOR = "<";
        public const string CHAR_VIRGULA = ",";
        public const string CHAR_PONTO = ".";

        public const string PROPERTYNAME = "{PropertyName}";

        #endregion
    }
}
