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
            AccountLocked
        }

        // Constants for authentication
        public const string MESSAGE_INVALID_USERNAME = "Incorrect Username or Email.";
        public const string MESSAGE_INVALID_PASSWORD = "Incorrect Password.";
        public const string MESSAGE_ACCOUNT_LOCKED = "Account Locked";
        public const string MESSAGE_LOGIN_FAILED = "Login failed due to an unexpected error. Please try again later.";
    }
}
