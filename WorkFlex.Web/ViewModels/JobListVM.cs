namespace WorkFlex.Web.ViewModels
{
    public class JobListVM
    {
        public string JobLocation { get; set; } = string.Empty;

        public string JobType { get; set; } = string.Empty;

        public string PostedWithin { get; set; } = string.Empty;

        public decimal? MinSalary { get; set; } = 0;

        public decimal? MaxSalary { get; set; } = 1000;

        public string SortBy { get; set; } = string.Empty;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 7;
    }
}
