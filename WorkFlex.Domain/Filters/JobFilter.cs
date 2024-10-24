namespace WorkFlex.Domain.Filters
{
    public class JobFilter
    {
        public string JobLocation { get; set; } = string.Empty;

        public string JobType { get; set; } = string.Empty;

        public string PostedWithin { get; set; } = string.Empty;

        public decimal? MinSalary { get; set; } = 0;

        public decimal? MaxSalary { get; set; } = 0;

        public string SortBy { get; set; } = string.Empty;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 7;
    }
}
