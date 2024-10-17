using System.Windows;
using WorkFlex.Services.Interface;

namespace WorkFlex.Desktop
{
    public partial class JobDetail : Window
    {
        private readonly IJobService _jobService;
        private readonly Guid _jobId;

        public JobDetail(Guid jobId, IJobService jobService)
        {
            InitializeComponent();
            _jobId = jobId;
            _jobService = jobService;

            LoadJobDetails();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadJobDetails();
        }

        private async void LoadJobDetails()
        {
            try
            {
                var jobDetail = await _jobService.GetJobByIdAsync(_jobId);
                if (jobDetail != null)
                {
                    DataContext = jobDetail;
                }
                else
                {
                    MessageBox.Show("Job detail not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading job details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackToList_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}