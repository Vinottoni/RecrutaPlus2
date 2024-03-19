namespace Safety.Domain.Constants
{
    public struct FuncionarioConst
    {
        public static string MSG_SELECIONE = "Selecione...";

        public static bool ATIVO_TRUE = true;
        public static bool ATIVO_FALSE = false;

        //Mensage Template
        public static string LOG_INDEX = "Controller: Funcionarios | Action: Index | User: {User} | Created: {Created}";
        public static string LOG_CREATE = "Controller: Funcionarios | Action: Create | User: {User} | Created: {Created}";
        public static string LOG_EDIT = "Controller: Funcionarios | Action: Edit | User: {User} | Created: {Created}";
        public static string LOG_DELETE = "Controller: Funcionarios | Action: Delete | User: {User} | Created: {Created}";
        public static string LOG_DETAILS = "Controller: Funcionarios | Action: Details | User: {User} | Created: {Created}";

        public static string LOG_EXCEPTION = "Controller: Funcionarios | Action: Details | User: {User} | Created: {Created} | Exception";
        public static string LOG_EXCEPTION_MSG = "Controller: Funcionarios | Action: Details | User: {User} | Created: {Created} | Exception: {Exception}";

        public static string LOG_TABLE_ADD = "Table: Funcionarios | Action: Add | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Funcionario}";
        public static string LOG_TABLE_UPDATE = "Table: Funcionarios | Action: Update | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Funcionario}";
        public static string LOG_TABLE_REMOVE = "Table: Funcionarios | Action: Remove | Created: {Created} | ConcurrencyStamp: {ConcurrencyStamp} | Id: {Id} | {@Funcionario}";
    }
}
