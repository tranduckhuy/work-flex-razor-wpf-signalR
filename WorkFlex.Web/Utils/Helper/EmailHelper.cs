using WorkFlex.Web.Constants;
using WorkFlex.Web.Untils.Helper.Interface;

namespace WorkFlex.Web.Untils.Helper
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
    }
}