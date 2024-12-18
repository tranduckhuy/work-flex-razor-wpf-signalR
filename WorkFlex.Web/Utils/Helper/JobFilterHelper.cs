﻿using WorkFlex.Web.Utils.Helper.Interface;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Utils.Helper
{
    public class JobFilterHelper : IJobFilterHelper
    {
        public bool AreFiltersEqual(JobPostRqVM filters1, JobPostRqVM filters2)
        {
            return filters1.JobLocation == filters2.JobLocation &&
                   filters1.JobType == filters2.JobType &&
                   filters1.PostedWithin == filters2.PostedWithin &&
                   filters1.MinSalary == filters2.MinSalary &&
                   filters1.MaxSalary == filters2.MaxSalary &&
                   filters1.SortBy == filters2.SortBy &&
                   filters1.PageNumber == filters2.PageNumber &&
                   filters1.PageSize == filters2.PageSize;
        }

        public bool IsFilterEmpty(JobPostRqVM filters)
        {
            return string.IsNullOrEmpty(filters.JobLocation) &&
                   string.IsNullOrEmpty(filters.JobType) &&
                   string.IsNullOrEmpty(filters.PostedWithin) &&
                   filters.MinSalary == 100 &&
                   filters.MaxSalary == 10000 &&
                   string.IsNullOrEmpty(filters.SortBy) &&
                   filters.PageNumber == 1 &&
                   filters.PageSize == 7;
        }
    }
}
