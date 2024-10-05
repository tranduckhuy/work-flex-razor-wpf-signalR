using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class JobPost
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [StringLength(50)]
        public string SalaryRange { get; set; } = string.Empty;

        [Required]
        public int IndustryId { get; set; }

        [Required]
        public string JobDescription { get; set; } = string.Empty;

        [StringLength(255)]
        public string JobLocation { get; set; } = string.Empty;

        [Required]
        public int JobTypeId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Status Status { get; set; } = Status.Active;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedAt { get; set; }

        public DateTime ExpiredAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Industry Industry { get; set; } = null!;
        public virtual JobType JobType { get; set; } = null!;
        public virtual ICollection<JobApplication> JobApplications { get; set; } = [];
    }
}