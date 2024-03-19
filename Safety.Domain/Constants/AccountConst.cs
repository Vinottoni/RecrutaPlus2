namespace Safety.Domain.Constants
{
    public struct AccountConst
    {
        //Controller Name
        public const string CONTROLLER_NAME = "Account";
        public const string ADMIN_NAME = "Administrador";
        public const string ADMIN_EMAIL = "admin@makeit.com.br";

        //Mensage Template
        public const string LOG_LOGIN = "Web | Account | Login | User: {User} | Local: {Local} | Remote: {Remote} | Created: {Created}";
        public const string LOG_LOGOUT = "Web | Account | Logout | User: {User} | Created: {Created}";
        public const string LOG_CONFIRM = "Web | Account | Confirm | User: {User} | Created: {Created}";
        public const string LOG_FORGOTPASSWORD = "Web | Account | ForgotPassword | User: {User} | Created: {Created}";

        public const string LOG_INDEX = "Web | Account | Index | User: {User} | Created: {Created}";
        public const string LOG_CREATE = "Web | Account | Create | User: {User} | Created: {Created}";
        public const string LOG_EDIT = "Web | Account | Edit | User: {User} | Created: {Created}";
        public const string LOG_DELETE = "Web | Account | Delete | User: {User} | Created: {Created}";
        public const string LOG_DETAILS = "Web | Account | Details | User: {User} | Created: {Created}";
    }
}
