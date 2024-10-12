using System.Windows;
using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Desktop.BusinessObject.Service.Interface;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for WindowJobCreate.xaml
    /// </summary>
    public partial class WindowJobCreate : Window
    {
        private readonly MainWindow _mainWindow;
        private readonly IJobPostService _jobPostService;

        public WindowJobCreate(MainWindow mainWindow, IJobPostService jobPostService)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _jobPostService = jobPostService;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxJobType.ItemsSource = _jobPostService.GetAllJobTypes();
            comboBoxJobType.DisplayMemberPath = "TypeName";
            comboBoxJobType.SelectedValuePath = "Id";

            comboBoxIndustry.ItemsSource = _jobPostService.GetAllIndustries();
            comboBoxIndustry.DisplayMemberPath = "IndustryName";
            comboBoxIndustry.SelectedValuePath = "Id";

            if (!string.IsNullOrEmpty(txtBoxIdJob.Text))
            {
                var jobPostDto = _jobPostService.GetJobPostById(txtBoxIdJob.ToString());
                if (jobPostDto == null)
                {
                    MessageBox.Show("Not Found Job Post!", "Not Found Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                txtBoxTitleJob.Text = jobPostDto.Title;
                txtBoxDescriptionJob.Text = jobPostDto.JobDescription;
                txtBoxSalaryRange.Text = jobPostDto.SalaryRange;
                comboBoxJobType.SelectedValue = jobPostDto.JobTypeId;
                comboBoxIndustry.SelectedValue = jobPostDto.IndustryId;
                txtBoxLocation.Text = jobPostDto.JobLocation;

                txtBoxIdJob.Visibility = Visibility.Visible;
                labelRecruiterId.Visibility = Visibility.Visible;
                labelRecruiterId.Visibility = Visibility.Visible;
                btnCreate.Content = "Update";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtBoxTitleJob.Text) ||
                string.IsNullOrWhiteSpace(txtBoxDescriptionJob.Text) ||
                string.IsNullOrWhiteSpace(txtBoxSalaryRange.Text) ||
                comboBoxJobType.SelectedItem == null ||
                comboBoxIndustry.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtBoxLocation.Text))
                {
                    MessageBox.Show("Please fill in all information!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedStatus = Domain.Status.Active;
                JobPostDTO jobPostDTO = new JobPostDTO
                {
                    Title = txtBoxTitleJob.Text,
                    SalaryRange = txtBoxSalaryRange.Text,
                    JobDescription = txtBoxDescriptionJob.Text,
                    JobLocation = txtBoxDescriptionJob.Text,
                    Status = selectedStatus,
                    JobTypeId = (int) comboBoxJobType.SelectedValue,
                    IndustryId = (int) comboBoxIndustry.SelectedValue,
                };

                _jobPostService.AddJobPost(jobPostDTO);

                _mainWindow.RefreshJobList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }

}
