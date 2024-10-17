using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Desktop.BusinessObject.Service.Interface;

namespace WorkFlex.Desktop
{
    public partial class WindowJobEdit : Window
    {
        private readonly MainWindow _mainWindow;
        private readonly IJobPostService _jobPostService;
        private readonly JobPostDTO _jobPostDTO;

        public WindowJobEdit(MainWindow mainWindow, IJobPostService jobPostService, JobPostDTO jobPostDTO)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _jobPostService = jobPostService;
            _jobPostDTO = jobPostDTO;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxJobType.ItemsSource = _jobPostService.GetAllJobTypes();
            comboBoxJobType.DisplayMemberPath = "TypeName";
            comboBoxJobType.SelectedValuePath = "Id";

            comboBoxIndustry.ItemsSource = _jobPostService.GetAllIndustries();
            comboBoxIndustry.DisplayMemberPath = "IndustryName";
            comboBoxIndustry.SelectedValuePath = "Id";

            txtBoxTitleJob.Text = _jobPostDTO.Title;
            txtBoxDescriptionJob.Text = _jobPostDTO.JobDescription;
            txtBoxSalaryRange.Text = _jobPostDTO.SalaryRange;
            comboBoxJobType.SelectedValue = _jobPostDTO.JobTypeId;
            comboBoxIndustry.SelectedValue = _jobPostDTO.IndustryId;
            txtBoxLocation.Text = _jobPostDTO.JobLocation;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                _jobPostDTO.Title = txtBoxTitleJob.Text;
                _jobPostDTO.JobDescription = txtBoxDescriptionJob.Text;

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
                    _jobPostDTO.SalaryRange = $"{minSalary} - {maxSalary}";
                }
                else
                {
                    MessageBox.Show("Please enter the correct format: Min - Max (100 - 10000).", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _jobPostDTO.JobTypeId = (int)comboBoxJobType.SelectedValue;
                _jobPostDTO.IndustryId = (int)comboBoxIndustry.SelectedValue;
                _jobPostDTO.JobLocation = txtBoxLocation.Text;

                _jobPostService.UpdateJobPost(_jobPostDTO);
                _mainWindow.RefreshJobList();
                this.Close();
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
