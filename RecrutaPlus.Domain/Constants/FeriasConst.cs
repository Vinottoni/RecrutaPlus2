namespace RecrutaPlus.Domain.Constants
{
    public struct FeriasConst
    {
        public static string MSG_SELECIONE = "Selecione...";

        public static bool ATIVO_TRUE = true;
        public static bool ATIVO_FALSE = false;

        //Mensage Template
        public static string LOG_INDEX = "Controller: Ferias | Action: Index | User: {User} | Created: {Created}";
        public static string LOG_CREATE = "Controller: Ferias | Action: Create | User: {User} | Created: {Created}";
        public static string LOG_EDIT = "Controller: Ferias | Action: Edit | User: {User} | Created: {Created}";
        public static string LOG_DELETE = "Controller: Ferias | Action: Delete | User: {User} | Created: {Created}";
        public static string LOG_DETAILS = "Controller: Ferias | Action: Details | User: {User} | Created: {Created}";

        public static string LOG_EXCEPTION = "Controller: Ferias | Action: Details | User: {User} | Created: {Created} | Exception";
        public static string LOG_EXCEPTION_MSG = "Controller: Ferias | Action: Details | User: {User} | Created: {Created} | Exception: {Exception}";

        public static string LOG_TABLE_ADD = "Table: Ferias | Action: Add | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Ferias}";
        public static string LOG_TABLE_UPDATE = "Table: Ferias | Action: Update | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Ferias}";
        public static string LOG_TABLE_REMOVE = "Table: Ferias | Action: Remove | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Ferias}";
    }
}
