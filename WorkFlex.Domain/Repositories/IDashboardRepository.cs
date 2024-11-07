namespace WorkFlex.Domain.Repositories
{
    public interface IDashboardRepository
    {
		Task<int> TotalUser();

		Task<int> TotalRecruiter();

		Task<int> TotalJobPost();

		Task<int> TotalApplicant();

		Task<List<int>> TotalUserMonth();

        Task<List<int>> TotalRecruiterMonth();

        Task<List<int>> TotalJobPostMonth();

        Task<List<int>> TotalApplicantMonth();
    }
}
