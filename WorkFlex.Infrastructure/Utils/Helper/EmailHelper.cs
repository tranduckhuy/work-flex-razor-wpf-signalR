using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Utils.Helper.Interface;

namespace WorkFlex.Infrastructure.Utils.Helper
{
    public class EmailHelper : IEmailHelper
    {
        public string RenderBodyResetPassword(string resetLink)
        {
            string bodyEmail = MailConstants.MAIL_RESET_CONTENT.Replace("{resetLink}", resetLink);
            return bodyEmail;
        }

        public string RenderBodyActiveAccount(string activationLink)
        {
            string bodyEmail = MailConstants.MAIL_ACTIVATE_CONTENT.Replace("{activationLink}", activationLink);
            return bodyEmail;
        }

        public string RenderBodyRecruiterApproval(string approvalLink)
        {
            string bodyEmail = MailConstants.MAIL_RECRUITER_APPROVAL_CONTENT.Replace("{approvalLink}", approvalLink);
            return bodyEmail;
        }

        public string RenderBodyRecruiterDecline(string reapplyLink)
        {
            string bodyEmail = MailConstants.MAIL_RECRUITER_DECLINE_CONTENT.Replace("{reapplyLink}", reapplyLink);
            return bodyEmail;
        }
    }
}