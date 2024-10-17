using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Desktop
{
    public partial class WindowJobEdit : Window
    {
        private readonly MainWindow _mainWindow;
        private readonly IJobService _jobService;

        public WindowJobEdit(MainWindow mainWindow, IJobService jobService)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _jobService = jobService;
        }

        public JobPostDto JobPostDto { get; set; } = null!;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxJobType.ItemsSource = await _jobService.GetJobTypesAsync();
            comboBoxJobType.DisplayMemberPath = "TypeName";
            comboBoxJobType.SelectedValuePath = "Id";

            comboBoxIndustry.ItemsSource = await _jobService.GetIndustriesAsync();
            comboBoxIndustry.DisplayMemberPath = "IndustryName";
            comboBoxIndustry.SelectedValuePath = "Id";

            txtBoxTitleJob.Text = JobPostDto.Title;
            txtBoxDescriptionJob.Text = JobPostDto.JobDescription;
            txtBoxSalaryRange.Text = JobPostDto.SalaryRange;
            comboBoxJobType.SelectedValue = JobPostDto.JobTypeId;
            comboBoxIndustry.SelectedValue = JobPostDto.IndustryId;
            txtBoxLocation.Text = JobPostDto.JobLocation;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                JobPostDto.Title = txtBoxTitleJob.Text;
                JobPostDto.JobDescription = txtBoxDescriptionJob.Text;

                JobPostDto.JobTypeId = (int)comboBoxJobType.SelectedValue;
                JobPostDto.IndustryId = (int)comboBoxIndustry.SelectedValue;

                JobPostDto.JobLocation = txtBoxLocation.Text;

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
                    JobPostDto.SalaryRange = $"{minSalary} - {maxSalary}";
                }
                else
                {
                    MessageBox.Show("Please enter the correct format: Min - Max (100 - 10000).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (await _jobService.UpdateJobPostAsync(JobPostDto))
                {
                    MessageBox.Show(AppConstants.MESSAGE_UPDATE_JOB_SUCCESSFULLY, "Update Job", MessageBoxButton.OK, MessageBoxImage.Information);
                    _mainWindow.RefreshJobList();
                    this.Close();
                } else
                {
                    MessageBox.Show(AppConstants.MESSAGE_UPDATE_JOB_FAILED, "Update Job", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter complete information and ensure valid values!");
            }
        }

        private bool ValidateFields()
        {
            return !string.IsNullOrWhiteSpace(txtBoxTitleJob.Text) &&
                   !string.IsNullOrWhiteSpace(txtBoxDescriptionJob.Text) &&
                   !string.IsNullOrWhiteSpace(txtBoxSalaryRange.Text) &&
                   comboBoxJobType.SelectedItem != null &&
                   comboBoxIndustry.SelectedItem != null &&
                   !string.IsNullOrWhiteSpace(txtBoxLocation.Text);
        }

        private void txtBoxSalaryRange_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            int caretIndex = textBox.SelectionStart;

            if ((caretIndex == 0 || caretIndex == 4) && (e.Key == Key.Back || e.Key == Key.Delete))
            {
                e.Handled = true;
            }

            if (textBox.Text.Length == 0)
            {
                textBox.Text = " - ";
                textBox.SelectionStart = textBox.Text.Length;
                e.Handled = true;
            }
        }

        private void txtBoxSalaryRange_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9-]+$");
        }

        private void txtBoxSalaryRange_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
        }

        private void txtBoxSalaryRange_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxSalaryRange.Text))
            {
                txtBoxSalaryRange.Text = " - ";
            }
        }
    }
}
