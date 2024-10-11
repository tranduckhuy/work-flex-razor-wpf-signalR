using WorkFlex.Domain;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Web.DTOs
{
    public class JobListDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string SalaryRange { get; set; } = string.Empty;

        public string JobDescription { get; set; } = string.Empty;

        public string JobLocation { get; set; } = string.Empty;

        public string DisplayCreatedAt { get; set; } = String.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiredAt { get; set; }

        public Status Status { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual Industry Industry { get; set; } = null!;

        public virtual JobType JobType { get; set; } = null!;

        public virtual ICollection<JobApplication> JobApplications { get; set; } = [];  
    }
}
