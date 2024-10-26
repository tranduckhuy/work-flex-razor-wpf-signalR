using System.ComponentModel.DataAnnotations;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain;

namespace WorkFlex.Services.DTOs
{
    public class JobApplicantDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid JobPostId { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime ApplicationDate { get; set; }

        public string CvFile { get; set; } = string.Empty;

        public Status Status { get; set; } = Status.Pending;

        public User User { get; set; } = null!;

        public JobPost JobPost { get; set; } = null!;
    }
}
