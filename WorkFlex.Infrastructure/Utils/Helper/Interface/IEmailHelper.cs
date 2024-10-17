namespace WorkFlex.Infrastructure.Utils.Helper.Interface
{
    public interface IEmailHelper
    {
        string RenderBodyResetPassword(string resetLink);

        string RenderBodyActiveAccount(string activationLink);
    }
}
