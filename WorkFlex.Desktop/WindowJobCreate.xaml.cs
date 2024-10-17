using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WorkFlex.Desktop.BusinessObject;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for WindowJobCreate.xaml
    /// </summary>
    public partial class WindowJobCreate : Window
    {
        private readonly MainWindow _mainWindow;
        private readonly IJobService _jobService;

        public WindowJobCreate(MainWindow mainWindow, IJobService jobService)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _jobService = jobService;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBoxSalaryRange.Text = " - "; 

            comboBoxJobType.ItemsSource = await _jobService.GetJobTypesAsync();
            comboBoxJobType.DisplayMemberPath = "TypeName";
            comboBoxJobType.SelectedValuePath = "Id";

            comboBoxIndustry.ItemsSource = await _jobService.GetIndustriesAsync();
            comboBoxIndustry.DisplayMemberPath = "IndustryName";
            comboBoxIndustry.SelectedValuePath = "Id";

            if (!string.IsNullOrEmpty(txtBoxIdJob.Text))
            {
                var jobPostDto = await _jobService.GetJobByIdAsync(Guid.Parse(txtBoxIdJob.ToString()));
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
                btnCreate.Content = "Update";
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
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

                string[] parts = txtBoxSalaryRange.Text.Split('-');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0].Trim().Replace(" ", ""), out int minSalary) &&
                    int.TryParse(parts[1].Trim().Replace(" ", ""), out int maxSalary))
                {
                    if (minSalary < 100 || maxSalary > 10000 || minSalary > maxSalary)
                    {
                        MessageBox.Show("Please enter a valid value from 100 to 10000 and Min cannot be greater than Max.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    JobPostDto jobPostDto = new JobPostDto
                    {
                        Title = txtBoxTitleJob.Text,
                        SalaryRange = $"{minSalary} - {maxSalary}",
                        JobDescription = txtBoxDescriptionJob.Text,
                        JobLocation = txtBoxLocation.Text,
                        Status = (int)Domain.Status.Active,
                        JobTypeId = (int)comboBoxJobType.SelectedValue,
                        IndustryId = (int)comboBoxIndustry.SelectedValue,
                        UserId = UserSession.Instance.GetUser().Id
                    };

                    await _jobService.AddJobPostAsync(jobPostDto);
                    _mainWindow.RefreshJobList();
                    Close();
                }
                else
                {
                    MessageBox.Show("Please enter the correct format: Min - Max (100 - 10000).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void txtBoxSalaryRange_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            int caretIndex = textBox.SelectionStart;

            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (caretIndex == 0 || caretIndex == 4)
                {
                    e.Handled = true;
                }
            }

            if (textBox.Text.Length == 0)
            {
                textBox.Text = " - ";
                textBox.SelectionStart = textBox.Text.Length;
                e.Handled = true;
            }
        }

        private void txtBoxSalaryRange_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

        }

        private void txtBoxSalaryRange_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9-]+$");
        }

        private void txtBoxSalaryRange_Loaded(object sender, RoutedEventArgs e)
        {
            txtBoxSalaryRange.Text = " - "; 
        }

    }
}
