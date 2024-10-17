namespace WorkFlex.Infrastructure.Constants
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
            AccountInactive,
			Error
        }

        public enum RegisterResult
        {
            Success,
            EmailExist,
            NotMatchPassword,
            Error
		}

		public enum ActivateResult
		{
			Success,
			InvalidToken,
            TokenExpired,
			Error
		}

		// Constants for default values
		public const string DEFAULT_AVATAR = "https://static.vecteezy.com/system/resources/thumbnails/009/734/564/small_2x/default-avatar-profile-icon-of-social-media-user-vector.jpg";
        public const string UNDEFINE = "Undefine";
        public const string YOU = "Yourself";

        // Message Constants
        // 1. Success messages (Authentication)
        public const string MESSAGE_REGISTER_SUCCESS = "We have sent an activation email to your account. Please check your inbox.";
        public const string MESSAGE_ACIVATE_ACCOUNT_SUCCESS = "Account activated successfully. You can now log in.";
        // 2. Success messages (Constant messages)
        public const string MESSAGE_ADD_JOB_SUCCESS = "Job added successfully!";
        public const string MESSAGE_UPDATE_JOB_SUCCESSFULLY = "Job updated successfully!";
        public const string MESSAGE_DELETE_JOB_SUCCESSFULLY = "Job deleted successfully!";
        // 3. Failed messages (Authentication)
        public const string MESSAGE_INVALID_USERNAME = "Incorrect Username or Email.";
        public const string MESSAGE_INVALID_PASSWORD = "Incorrect Password.";
        public const string MESSAGE_ACCOUNT_LOCKED = "Account Locked. Please contact with adminstrator for more information.";
        public const string MESSAGE_ACCOUNT_INACTIVE = "Account Inactive. Please active your account by link in your email.";
		public const string MESSAGE_EMAIL_EXIST = "Email is already exist.";
        public const string MESSAGE_LOGIN_FAILED = "Login Failed!";
        public const string MESSAGE_NOT_MATCH_PASSWORD = "Password and Repeat Password are not match.";
        public const string MESSAGE_INVALID_ACTIVATION_LINK = "Invalid activation link.";
        public const string MESSAGE_ACTIVATE_TOKEN_EXPIRED = "Your request has expired. A new activate link has been sent to your email.";
        public const string MESSAGE_UNAUTHORIZED = "You do not have permission to access this feature. Please contact the administrator if you need assistance.";
		public const string MESSAGE_FAILED = "Error occurred during execution. Please try again later.";
        // 4. Failed messages (Constant messages)
        public const string MESSAGE_JOB_NOT_FOUND = "The job you're looking for does not exist. Please verify the ID and try again.";
        public const string MESSAGE_ADD_JOB_FAILED = "Add unsuccessful. Please ensure all fields are correct and try again.";
        public const string MESSAGE_UPDATE_JOB_FAILED = "Update unsuccessful. Please ensure all fields are correct and try again.";
        public const string MESSAGE_DELETE_JOB_FAILED = "Deletion unsuccessful. Please ensure the job exists and try again.";

        // Session & Temp data & Pages name constants
        // 1. Session
        public const string ID = "Id";
        public const string USERNAME = "Username";
        public const string NAME = "Name";
        public const string AVATAR = "Avatar";
        public const string LOCATION= "Location";
        public const string ROLE = "Role";
        // 2. Temp data
        public const string TEMP_DATA_FAILED_MESSAGE = "FailedMessage";
        public const string TEMP_DATA_SUCCESS_MESSAGE = "SuccessMessage";
        public const string MESSAGE_LOGIN_REQUIRED = "You need to login to access this page.";
        // 3. Pages name (Pages URL)
        public const string PAGE_HOME = "/Home/Index";
        public const string PAGE_ERROR = "/Error/Error";
        public const string PAGE_LOGIN = "/Authen/Login";
        public const string PAGE_JOB_LIST = "/Job/JobList";
        public const string PAGE_JOB_APPLY = "/Job/JobApply";
        public const string PAGE_DASHBOARD = "/Dashboard/Dashboard";

        // Constants Repository
        public const string ALL = "All";
        public const string ANY = "Any";
        public const string NONE = "None";
        public const string ANY_WHERE = "Anywhere";

    }
}