namespace Safety.Domain.Constants
{
    public struct LoginConst
    {
        public static string MSG_SELECIONE = "Selecione...";

        //Mensage Template
        public static string LOG_INDEX = "Controller: Logins | Action: Index | User: {User} | Created: {Created}";
        public static string LOG_CREATE = "Controller: Logins | Action: Create | User: {User} | Created: {Created}";
        public static string LOG_EDIT = "Controller: Logins | Action: Edit | User: {User} | Created: {Created}";
        public static string LOG_DELETE = "Controller: Logins | Action: Delete | User: {User} | Created: {Created}";
        public static string LOG_DETAILS = "Controller: Logins | Action: Details | User: {User} | Created: {Created}";

        public static string LOG_EXCEPTION = "Controller: Logins | Action: Details | User: {User} | Created: {Created} | Exception";
        public static string LOG_EXCEPTION_MSG = "Controller: Logins | Action: Details | User: {User} | Created: {Created} | Exception: {Exception}";

        public static string LOG_TABLE_ADD = "Table: Logins | Action: Add | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Login}";
        public static string LOG_TABLE_UPDATE = "Table: Logins | Action: Update | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Login}";
        public static string LOG_TABLE_REMOVE = "Table: Logins | Action: Remove | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Login}";
    }
}
