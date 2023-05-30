namespace RecrutaPlus.Domain.Constants
{
    public struct CargoConst
    {
        public static string MSG_SELECIONE = "Selecione...";

        //Mensage Template
        public static string LOG_INDEX = "Controller: Cargos | Action: Index | User: {User} | Created: {Created}";
        public static string LOG_CREATE = "Controller: Cargos | Action: Create | User: {User} | Created: {Created}";
        public static string LOG_EDIT = "Controller: Cargos | Action: Edit | User: {User} | Created: {Created}";
        public static string LOG_DELETE = "Controller: Cargos | Action: Delete | User: {User} | Created: {Created}";
        public static string LOG_DETAILS = "Controller: Cargos | Action: Details | User: {User} | Created: {Created}";

        public static string LOG_EXCEPTION = "Controller: Cargos | Action: Details | User: {User} | Created: {Created} | Exception";
        public static string LOG_EXCEPTION_MSG = "Controller: Cargos | Action: Details | User: {User} | Created: {Created} | Exception: {Exception}";

        public static string LOG_TABLE_ADD = "Table: Cargos | Action: Add | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Cargo}";
        public static string LOG_TABLE_UPDATE = "Table: Cargos | Action: Update | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Cargo}";
        public static string LOG_TABLE_REMOVE = "Table: Cargos | Action: Remove | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Cargo}";
    }
}
