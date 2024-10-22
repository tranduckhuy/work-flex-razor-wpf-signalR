namespace WorkFlex.Infrastructure.Constants
{
    public class MailConstants
    {
        public static string GenerateEmailContent(string title, string description, string bodyText, string actionLink, string buttonText)
        {
            return $@"
            <!DOCTYPE html>
            <html lang='en-US'>

                <head>
                    <meta content='text/html; charset=utf-8' http-equiv='Content-Type' />
                    <title>{title}</title>
                    <meta name='description' content='{description}'>
                    <style type='text/css'>
                        a:hover {{text-decoration: underline !important;}}
                    </style>
                </head>

                <body marginheight='0' topmargin='0' marginwidth='0' style='margin: 0px; background-color: #f2f3f8;' leftmargin='0'>
                    <table cellspacing='0' border='0' cellpadding='0' width='100%' bgcolor='#f2f3f8'
                            style='@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;'>
                        <tr>
                            <td>
                                <table style='background-color: #f2f3f8; max-width:670px; margin:0 auto;' width='100%' border='0'
                                        align='center' cellpadding='0' cellspacing='0'>
                                    <tr>
                                        <td style='height:80px;'>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style='text-align:center;'>
                                            <a href='#!' title='logo'>
                                            <img width='200' src='https://firebasestorage.googleapis.com/v0/b/gdupa-2fa82.appspot.com/o/logo%2Fgdupa-high-resolution-logo-transparent.png?alt=media&token=c438141e-e081-48e3-8b9d-b270bd160fde' title='logo' alt='logo'>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style='height:20px;'>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width='95%' border='0' align='center' cellpadding='0' cellspacing='0'
                                                    style='max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);'>
                                                <tr>
                                                    <td style='height:40px;'>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style='padding:0 35px;'>
                                                        <h1 style='color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;'>{bodyText}</h1>
                                                        <span style='display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;'></span>
                                                        <p style='color:#455056; font-size:15px;line-height:24px; margin:0;'>
                                                            {description}
                                                        </p>
                                                        <a href='{actionLink}' target='_blank' rel='noopener'
                                                            style='background:#87CEFA;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;'>
                                                            {buttonText}
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style='height:40px;'>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    <tr>
                                        <td style='height:20px;'>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style='height:80px;'>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </body>
            </html>";
        }

        public static string MAIL_RESET_CONTENT => GenerateEmailContent(
            "Reset Password",
            "We cannot simply send you your old password. A unique link to reset your password has been generated for you. To reset your password, click the following link and follow the instructions.",
            "You have requested to reset your password",
            "{resetLink}",
            "Reset Password");

        public static string MAIL_ACTIVATE_CONTENT => GenerateEmailContent(
            "Activate Account",
            "Thank you for registering with us! To complete the activation of your account, please click the button below. Once your account is activated, you can log in and start using our services.",
            "Please activate your account",
            "{activationLink}",
            "Activate Account");

        public static string MAIL_RECRUITER_DECLINE_CONTENT => GenerateEmailContent(
            "Recruiter Request Declined",
            "Please review the required information and submit your request again. We appreciate your interest, but it appears that some required information was not met. Please review the requirements and submit your application again.",
            "Your request to become a recruiter has been declined.",
            "{reapplyLink}",
            "Reapply Now"
        );

        public static string MAIL_RECRUITER_APPROVAL_CONTENT => GenerateEmailContent(
            "Recruiter Request Approved",
            "Congratulations! Your request to become a recruiter has been approved. You can now start posting jobs and searching for candidates.",
            "Your request to become a recruiter has been approved.",
            "{approvalLink}",
            "Start Posting Jobs"
        );
    }
}
