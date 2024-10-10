using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.Constants;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Pages.Authen
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly IAuthenService _authenService;

        public RegisterModel(ILogger<RegisterModel> logger, IAuthenService authenService)
        {
            _logger = logger;
            _authenService = authenService;
        }

        public RegisterVM RegisterVM { get; set; } = null!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(RegisterVM registerVm)
        {
            _logger.LogInformation("[OnPost]: Controller - Start add a new user");
            try
            {
                var registerResult = _authenService.AddUser(registerVm);
                _logger.LogDebug("[OnPost]: Controller - Register result: {registerResult}", registerResult);
                switch (registerResult)
                {
                    case AppConstants.RegisterResult.Success:
                        TempData[AppConstants.TEMP_DATA_MESSAGE_REGISTER_SUCCESS] = AppConstants.MESSAGE_REGISTER_SUCCESS;
                        return RedirectToPage(AppConstants.PAGE_LOGIN);
                    case AppConstants.RegisterResult.EmailExist:
                        TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_EMAIL_EXIST;
                        break;
                    case AppConstants.RegisterResult.NotMatchPassword:
                        TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_NOT_MATCH_PASSWORD;
                        break;
                    default:
                        TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_FAILED;
                        break;
                }
                _logger.LogInformation("[OnPost]: Controller - End add a new user with result: {registerResult}", registerResult);
            }
            catch (Exception ex)
            {
                TempData[AppConstants.TEMP_DATA_MESSAGE] = AppConstants.MESSAGE_FAILED;
                _logger.LogError("[OnPost]: Controller - End add a new user with error: {ex}", ex.StackTrace);
                return Page();
            }
            
            return Page();
        }
    }
}
