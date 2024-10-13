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
