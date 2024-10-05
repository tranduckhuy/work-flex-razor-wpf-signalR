using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        public string TypeName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; } = [];
    }
}