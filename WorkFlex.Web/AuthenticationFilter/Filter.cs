using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WorkFlex.Infrastructure.Constants;

namespace WorkFlex.Web.AuthenticationFilter
{
    public class Filter : IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var page = context.ActionDescriptor.ViewEnginePath; // Get URL of current page

            // If page from "/User" folder and not "/User/Profile"
            if ((page.StartsWith("/User", StringComparison.OrdinalIgnoreCase) && page != "/User/Profile") || 
                page.StartsWith("/Dashboard", StringComparison.OrdinalIgnoreCase) ||
				page.StartsWith("/Recruiter", StringComparison.OrdinalIgnoreCase))
            {
                var roleIdBytes = context.HttpContext.Session.Get(AppConstants.ROLE);
                if (roleIdBytes != null)
                {
                    // Convert byte[] to byte
                    var roleId = BitConverter.ToInt32(roleIdBytes, 0);
                    if (roleId != 1)
                    {
                        // Redirect to Error page (403 page)
                        context.Result = new RedirectToPageResult("/Error/Error");
                        return;
                    }
                }
            }

            var user = context.HttpContext.Session.GetString(AppConstants.USERNAME);
            if (user == null)
            {
                context.Result = new RedirectToPageResult("/Authen/Login");
                return;
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }
    }
}
