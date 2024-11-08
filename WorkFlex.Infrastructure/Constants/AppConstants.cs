using System.Runtime.CompilerServices;

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

        public enum Role
        {
            Admin = 1,
            Recruiter = 2,
            JobSeeker = 3
        }

        public enum UserSearchOption
        {
            Name,
            Email
        }

        public enum JobPostSearchOption
        {
            Title,
            Location
        }

        public enum ProfileResult
        {
            Success,
            UserNotFound,
            InvalidPassword,
            PasswordNotMatch,
            Error
        }

        // Constants for default values
        public const string DEFAULT_AVATAR = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/avatar%2Fdefault_avatar.png?alt=media&token=8654c964-e226-4777-ac66-b60d4182d287";
		public const string DEFAULT_BGR_IMG = "https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/supplier-background%2Fprofile-cover.jpg?alt=media&token=cf51dca2-8021-40ee-bd58-66000ab49c10";
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
        public const string MESSAGE_CHANGE_PASSWORD_SUCCESSFULLY = "Your password changed successfully!";
        public const string MESSAGE_APPLY_JOB_SUCCESSFULLY = "You have sent request to apply for this job successfully!";
        public const string MESSAGE_UPDATE_PROFILE_SUCCESSFULLY = "Your profile updated successfully!";
        public const string MESSAGE_APPROVE_RECRUITER_REQUEST_SUCCESSFULLY = "Recruiter request approved successfully!";
        public const string MESSAGE_DECLINE_RECRUITER_REQUEST_SUCCESSFULLY = "Recruiter request declined successfully!";
        public const string MESSAGE_ACTION_SUCCESSFULLY = "Action completed successfully!";

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
        public const string MESSAGE_USER_NOT_FOUND = "The user you're looking for does not exist. Please verify the ID and try again.";
        public const string MESSAGE_ADD_JOB_FAILED = "Add unsuccessful. Please ensure all fields are correct and try again.";
        public const string MESSAGE_UPDATE_JOB_FAILED = "Update unsuccessful. Please ensure all fields are correct and try again.";
        public const string MESSAGE_DELETE_JOB_FAILED = "Deletion unsuccessful. Please ensure the job exists and try again.";
        public const string MESSAGE_INVALID_OLD_PASSWORD = "The old password you entered is incorrect. Please try again.";
        public const string MESSAGE_UPDATE_PROFILE_FAILED = "Update profile unsuccessfully. Please ensure all fields are filled and try again.";
        public const string MESSAGE_LOCKUNLOCK_USER_FAILED = "You can't lock or unlock yourself!. Please ensure all fields are filled and try again.";
        public const string MESSAGE_INVALID_JOB_POST_ID = "Invalid job post ID.";

        // Session & Temp data & Pages name constants
        // 1. Session
        public const string ID = "Id";
        public const string USERNAME = "Username";
        public const string NAME = "Name";
        public const string AVATAR = "Avatar";
        public const string LOCATION = "Location";
        public const string SUBSCRIPTION = "Subscription";
        public const string ROLE = "Role";
        // 2. Temp data
        public const string TEMP_DATA_SUCCESS_MESSAGE = "SuccessMessage";
        public const string TEMP_DATA_FAILED_MESSAGE = "FailedMessage";
        public const string MESSAGE_LOGIN_REQUIRED = "You need to login to do this action.";
        public const string MESSAGE_UNAUTHORIZED_ACTION = "You do not have permission to access this feature. Please contact the administrator if you need assistance.";
        // 3. Pages name (Pages URL)
        public const string PAGE_HOME = "/Home/Index";
        public const string PAGE_ERROR = "/Error/Error";
        public const string PAGE_LOGIN = "/Authen/Login";
        public const string PAGE_JOB_LIST = "/Job/JobList";
        public const string PAGE_JOB_APPLY = "/Job/JobApply";
        public const string PAGE_DASHBOARD = "/Dashboard/Dashboard";
        public const string PAGE_RECRUITER_REQUEST = "/Recruiter/RecruiterRequest";
        public const string PAGE_RECRUITER_LIST = "/Recruiter/RecruiterList";

        // Constants Repository
        public const int ALL_ROLE = 0;
        public const string ALL = "All";
        public const string ANY = "Any";
        public const string NONE = "None";
        public const string ANY_WHERE = "Anywhere";

    }
}
