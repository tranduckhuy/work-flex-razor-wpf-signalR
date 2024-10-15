using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;
using WorkFlex.Web.ViewModels;

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

        public async Task<IActionResult> OnGetAsync(Guid id, JobPostVM filters)
        {
            try
            {
                var result = await _jobService.GetJobByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                JobPost = result;

                return Page();
            } catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }
    }
}