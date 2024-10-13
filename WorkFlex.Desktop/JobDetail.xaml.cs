using System.Windows;
using WorkFlex.Desktop.BusinessObject.Service.Interface;

namespace WorkFlex.Desktop
{
    public partial class JobDetail : Window
    {
        private readonly IJobPostService _jobPostService;
        private readonly Guid _jobId;

        public JobDetail(Guid jobId, IJobPostService jobPostService)
        {
            InitializeComponent();
            _jobId = jobId;
            _jobPostService = jobPostService;
            LoadJobDetails();
        }

        private void LoadJobDetails()
        {
            try
            {
                var jobDetail = _jobPostService.GetJobById(_jobId);
                if (jobDetail != null)
                {
                    DataContext = jobDetail;
                }
                else
                {
                    MessageBox.Show("Job details not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading job details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackToList_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}