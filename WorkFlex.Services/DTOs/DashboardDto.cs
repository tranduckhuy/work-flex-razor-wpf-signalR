namespace WorkFlex.Services.DTOs
{
    public class DashboardDto
    {
		public int TotalUser { get; set; } = 0;

		public int TotalRecruiter { get; set; } = 0;

		public int TotalJobPost { get; set; } = 0;

		public int TotalApplicant { get; set; } = 0;

		public List<int> TotalUserMonth {  get; set; } = new List<int>();

        public List<int> TotalRecruiterMonth {  get; set; } = new List<int>();

        public List<int> TotalJobPostMonth {  get; set; } = new List<int>();

        public List<int> TotalApplicantMonth {  get; set; } = new List<int>();
	}
}
