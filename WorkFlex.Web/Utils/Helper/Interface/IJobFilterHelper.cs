using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Utils.Helper.Interface
{
    public interface IJobFilterHelper
    {
        bool AreFiltersEqual(JobPostVM filters1, JobPostVM filters2);

        bool IsFilterEmpty(JobPostVM filters);
    }
}
