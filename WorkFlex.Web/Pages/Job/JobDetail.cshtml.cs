using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Web.DTOs;
using WorkFlex.Web.Services.Interface;

namespace WorkFlex.Web.Pages.Job
{
    public class JobDetailModel : PageModel
    {
        private readonly IJobService _jobService;

        public JobDetailModel(IJobService jobService)
        {
            _jobService = jobService;
        }

        public JobPostDto JobPost { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var result = await _jobService.GetJobByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            JobPost = result;
            return Page();
        }
    }
}