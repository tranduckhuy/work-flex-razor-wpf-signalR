using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Utils.Helper.Interface
{
    public interface IJobFilterHelper
    {
        bool AreFiltersEqual(JobPostRqVM filters1, JobPostRqVM filters2);

        bool IsFilterEmpty(JobPostRqVM filters);
    }
}
