﻿namespace WorkFlex.Web.Untils.Helper.Interface
{
    public interface IEmailHelper
    {
        string RenderBodyResetPassword(string resetLink);

        string RenderBodyActiveAccount(string activationLink);
	}
}