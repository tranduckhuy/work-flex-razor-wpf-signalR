namespace WorkFlex.Web.Constants
{
    public class MailConstants
    {
        public const string MAIL_RESET_CONTENT = @"
            <!DOCTYPE html>
            <html lang='en-US'>

                <head>
                    <meta content='text/html; charset=utf-8' http-equiv='Content-Type' />
                    <title>Reset Password</title>
                    <meta name='description' content='Reset Password Email.'>
                    <style type='text/css'>
                        a:hover {{text-decoration: underline !important;}}
                    </style>
                </head>

                <body marginheight='0' topmargin='0' marginwidth='0' style='margin: 0px; background-color: #f2f3f8;' leftmargin='0'>
                    <table cellspacing='0' border='0' cellpadding='0' width='100%' bgcolor='#f2f3f8'
                            style='@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;'>
                        <tr>
                            <td>
                                <table style='background-color: #f2f3f8; max-width:670px;  margin:0 auto;' width='100%' border='0'
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
                                                        <h1 style='color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;'>You have
                                                            requested to reset your password</h1>
                                                        <span style='display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;'></span>
                                                        <p style='color:#455056; font-size:15px;line-height:24px; margin:0;'>
                                                            We cannot simply send you your old password. A unique link to reset your
                                                            password has been generated for you. To reset your password, click the
                                                            following link and follow the instructions.
                                                        </p>
                                                        <a href='{resetLink}'
                                                            style='background:#87CEFA;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;'>Reset
                                                            Password
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

		public const string MAIL_ACTIVATE_CONTENT = @"
            <!DOCTYPE html>
            <html lang='en-US'>

                <head>
                    <meta content='text/html; charset=utf-8' http-equiv='Content-Type' />
                    <title>Reset Password</title>
                    <meta name='description' content='Activate Account Email.'>
                    <style type='text/css'>
                        a:hover {{text-decoration: underline !important;}}
                    </style>
                </head>

                <body marginheight='0' topmargin='0' marginwidth='0' style='margin: 0px; background-color: #f2f3f8;' leftmargin='0'>
                    <table cellspacing='0' border='0' cellpadding='0' width='100%' bgcolor='#f2f3f8'
                            style='@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;'>
                        <tr>
                            <td>
                                <table style='background-color: #f2f3f8; max-width:670px;  margin:0 auto;' width='100%' border='0'
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
                                                        <h1 style='color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;'>
                                                            Please activate your account
                                                        </h1>
                                                        <span style='display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;'></span>
                                                        <p style='color:#455056; font-size:15px;line-height:24px; margin:0;'>
                                                            Thank you for registering with us! 
                                                            To complete the activation of your account, please click the button below.
                                                        </p>
                                                        <p style='color:#455056; font-size:15px;line-height:24px; margin:0 0 25px;'>
                                                            Once your account is activated, you can log in and start using our services.
                                                        </p>
                                                        <a href='{activationLink}'
                                                            style='background:#87CEFA;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;'>
                                                            Activate Account
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
}
