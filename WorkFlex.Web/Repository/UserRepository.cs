using WorkFlex.Domain.Entities;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.Repository.Interface;
using WorkFlex.Web.Untils.Helper.Interface;
using WorkFlex.Web.Untils.Mail;

namespace WorkFlex.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly SendMailUtil _sendMailUtil;
        private readonly IEmailHelper _emailHelper;

        public UserRepository(AppDbContext appDbContext, SendMailUtil sendMailUtil, IEmailHelper emailHelper)
        {
            _appDbContext = appDbContext;
            _sendMailUtil = sendMailUtil;
            _emailHelper = emailHelper;
        }

        public User? GetUserByEmail(string email)
        {
            return _appDbContext.Users.SingleOrDefault(u => u.Email == email);
        }

        public User? GetUserByUsername(string username)
        {
            return _appDbContext.Users.SingleOrDefault(u => u.Username == username);
        }

        public bool IsEmailExist(string email)
        {
            return _appDbContext.Users.Any(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public bool SendResetPasswordEmail(string userEmail, ISession session, HttpContext httpContext)
        {
            try
            {
                var user = GetUserByEmail(userEmail);
                if (user == null)
                {
                    return false; // Không tìm thấy người dùng
                }

                var resetToken = Guid.NewGuid().ToString();
                var resetTokenExpiryTime = DateTime.UtcNow.AddMinutes(5); // Thay đổi thời gian hết hạn

                // Lưu token vào session
                session.SetString("ResetToken", resetToken);
                session.SetString("ResetTokenExpiryTime", resetTokenExpiryTime.ToString());
                session.SetString("ResetTokenUserEmail", userEmail);

                var resetLink = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Authen/Reset?token={resetToken}";
                var mailContent = new MailContent
                {
                    To = userEmail,
                    Subject = "Reset Password",
                    Body = _emailHelper.RenderBodyResetPassword(resetLink)
                };

                _ = _sendMailUtil.SendMail(mailContent); // Gửi email không đồng bộ

                return true; // Gửi email thành công
            }
            catch (Exception)
            {
                return false; // Có lỗi xảy ra
            }
        }

        public bool ResetPassword(string newPassword, ISession session)
        {
            try
            {
                var sessionToken = session.GetString("ResetToken");
                var sessionExpiryTime = session.GetString("ResetTokenExpiryTime");
                var userEmailFromSession = session.GetString("ResetTokenUserEmail");

                if (string.IsNullOrEmpty(sessionToken) ||
                    string.IsNullOrEmpty(sessionExpiryTime) ||
                    DateTime.Parse(sessionExpiryTime) <= DateTime.UtcNow ||
                    string.IsNullOrEmpty(userEmailFromSession))
                {
                    return false; // Token không hợp lệ hoặc đã hết hạn
                }

                var user = GetUserByEmail(userEmailFromSession);
                if (user == null)
                {
                    return false; // Không tìm thấy người dùng
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword); // Mã hóa mật khẩu
                _appDbContext.SaveChanges(); // Lưu thay đổi

                // Xóa thông tin token khỏi session
                session.Remove("ResetToken");
                session.Remove("ResetTokenExpiryTime");
                session.Remove("ResetTokenUserEmail");

                return true; // Đặt lại mật khẩu thành công
            }
            catch (Exception)
            {
                return false; // Có lỗi xảy ra
            }
        }

    }
}
