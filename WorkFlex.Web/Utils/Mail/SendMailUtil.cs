using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace WorkFlex.Web.Untils.Mail
{
    public class SendMailUtil
    {
        private readonly ILogger<SendMailUtil> _logger;
        private MailSettings MailSettings { get; set; }

        public SendMailUtil(ILogger<SendMailUtil> logger, IOptions<MailSettings> mailSettings)
        {
            _logger = logger;
            MailSettings = mailSettings.Value;
        }

        public async Task<string> SendMail(MailContent mailContent)
        {
			_logger.LogInformation("[SendMail]: Mail - Start send mail with content: {mailContent}", mailContent);
			var email = new MimeMessage();
            email.Sender = new MailboxAddress(MailSettings.DisplayName, MailSettings.Email);
            email.From.Add(new MailboxAddress(MailSettings.DisplayName, MailSettings.Email));
            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            email.Subject = mailContent.Subject;

			var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;

            email.Body = builder.ToMessageBody();
			_logger.LogDebug("[SendMail]: Mail - Email Information: {email}", email);

			using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                await smtp.ConnectAsync(MailSettings.Host, MailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(MailSettings.Email, MailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception e)
            {
                _logger.LogError("Error occured while sending mail: {e}", e);
                return "Error " + e.Message;
            }
            await smtp.DisconnectAsync(true);

			_logger.LogInformation("[SendMail]: Mail - End send mail with status: Send Successfully");
			return "SEND SUCCESSFULLY";
        }
    }
    public class MailContent
    {
        public string To { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;
    }
}
