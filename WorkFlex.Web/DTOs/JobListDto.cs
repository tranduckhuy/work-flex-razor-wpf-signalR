using WorkFlex.Domain.Entities;

namespace WorkFlex.Web.DTOs
{
    public class JobListDto
    {
        public Guid JobId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string SalaryRange { get; set; } = string.Empty;

        public string JobDescription { get; set; } = string.Empty;

        public string JobLocation { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string DisplayCreatedAt { get; set; } = String.Empty;

        public virtual User User { get; set; } = null!;

        public virtual Industry Industry { get; set; } = null!;

        public virtual JobType JobType { get; set; } = null!;
    }
}
