using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Web.ViewModels
{
    public class JobApplyVM
    {
        public Guid JobPostId { get; set; } = Guid.Empty;
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your CV")]
        public string CVUrl { get; set; } = null!;
    }
}
