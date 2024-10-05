using System.ComponentModel.DataAnnotations;

namespace WorkFlex.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string RoleName { get; set; } = null!;

        public ICollection<User> Users { get; set; } = [];
    }
}