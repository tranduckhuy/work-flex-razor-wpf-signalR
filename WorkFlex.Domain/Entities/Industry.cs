using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class Industry
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string IndustryName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
        public virtual ICollection<JobPost> JobPosts { get; set; } = [];
    }
}