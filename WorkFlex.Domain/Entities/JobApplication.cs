using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class JobApplication
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid JobPostId { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        [Required, StringLength(255)]
        public string CvFile { get; set; } = string.Empty;

        public Status Status { get; set; } = Status.Pending;

        public virtual User User { get; set; } = null!;
        public virtual JobPost JobPost { get; set; } = null!;
    }
}