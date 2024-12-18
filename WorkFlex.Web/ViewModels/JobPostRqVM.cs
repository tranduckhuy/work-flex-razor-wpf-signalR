﻿namespace WorkFlex.Web.ViewModels
{
    public class JobPostRqVM
    {
        public string JobLocation { get; set; } = string.Empty;

        public string JobType { get; set; } = string.Empty;

        public string PostedWithin { get; set; } = string.Empty;

        public decimal? MinSalary { get; set; } = 100;

        public decimal? MaxSalary { get; set; } = 10000;

        public string SortBy { get; set; } = string.Empty;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 7;
    }
}
