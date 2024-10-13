using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlex.Desktop.BusinessObject.DTO
{
    public class IndustryDTO
    {
        public int Id { get; set; }
        public string IndustryName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
        public List<JobPostDTO> JobPosts { get; set; } = new List<JobPostDTO>();
    }
}
