namespace WorkFlex.Web.Constants
{
    public class AppConstants
    {
        // Enum for authentication
        public enum LoginResult
        {
            Success,
            UserNotFound,
            InvalidPassword,
            AccountLocked,
            Error
        }

        public enum RegisterResult
        {
            Success,
            EmailExist,
            NotMatchPassword,
            Error
        }

        // Constants for authentication
        public const string MESSAGE_INVALID_USERNAME = "Incorrect Username or Email.";
        public const string MESSAGE_INVALID_PASSWORD = "Incorrect Password.";
        public const string MESSAGE_ACCOUNT_LOCKED = "Account Locked.";
        public const string MESSAGE_REGISTER_SUCCESS = "Register successfully.";
        public const string MESSAGE_EMAIL_EXIST = "Email is already exist.";
        public const string MESSAGE_NOT_MATCH_PASSWORD = "Password and Repeat Password not match.";
        public const string MESSAGE_FAILED = "Error occurred during execution. Please try again later.";

        // Session & Temp data & Pages name constants
        // 1. Session
        public const string ID = "Id";
        public const string USERNAME = "Username";
        public const string AVATAR = "Avatar";
        public const string ROLE = "Role";
        // 2. Temp data
        public const string TEMP_DATA_MESSAGE = "Message";
        public const string TEMP_DATA_MESSAGE_REGISTER_SUCCESS = "RegisterMessage";
        // 3. Pages name (Pages URL)
        public const string PAGE_HOME = "/Home/Index";
        public const string PAGE_ERROR = "/Error/Error";
        public const string PAGE_LOGIN = "/Authen/Login";
        public const string PAGE_JOB_LIST = "/Job/JobList";
        public const string PAGE_JOB_APPLY = "/Job/JobApply";
    }
}
