namespace WorkFlex.Desktop.BusinessObject.DTO
{
    public class JobTypeDTO
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
