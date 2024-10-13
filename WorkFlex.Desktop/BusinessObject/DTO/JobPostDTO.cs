using WorkFlex.Domain;
using WorkFlex.Domain.Entities;

namespace WorkFlex.Desktop.BusinessObject.DTO
{
    public class JobPostDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string SalaryRange { get; set; } = string.Empty;

        public int IndustryId { get; set; }

        public string JobDescription { get; set; } = string.Empty;

        public string JobLocation { get; set; } = string.Empty;

        public string DisplayBriefLocation { get; set; } = String.Empty;

        public string DisplayCreatedAt { get; set; } = String.Empty;

        public int JobTypeId { get; set; }

        public Guid UserId { get; set; }

        public Status Status { get; set; } = Status.Active;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedAt { get; set; }

        public DateTime ExpiredAt { get; set; }

        public JobType JobType { get; set; } = null!;

        public Industry Industry { get; set; } = null!;

        public virtual ICollection<JobApplication> JobApplications { get; set; } = [];

    }
}
