﻿using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            txtBoxSalaryRange.Text = " - "; 

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

                    JobPostDTO jobPostDTO = new JobPostDTO
                    {
                        Title = txtBoxTitleJob.Text,
                        SalaryRange = $"{minSalary} - {maxSalary}", 
                        JobDescription = txtBoxDescriptionJob.Text,
                        JobLocation = txtBoxLocation.Text,
                        Status = (int)Domain.Status.Active,
                        JobTypeId = (int)comboBoxJobType.SelectedValue,
                        IndustryId = (int)comboBoxIndustry.SelectedValue,
                    };

                    _jobPostService.AddJobPost(jobPostDTO);
                    _mainWindow.RefreshJobList();
                    this.Close();
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

            if (string.IsNullOrEmpty(textBox.Text)) return;

            string input = textBox.Text.Replace(" ", "").Replace("-", "");

            if (input.Length > 8) return;

            string[] parts = textBox.Text.Split('-');

            string minPart = parts.Length > 0 ? parts[0].Trim() : "";
            string maxPart = parts.Length > 1 ? parts[1].Trim() : "";

            TimeSpan timeout = TimeSpan.FromMilliseconds(100);
            minPart = Regex.Replace(minPart, @"^0+", "", RegexOptions.None, timeout);
            maxPart = Regex.Replace(maxPart, @"^0+", "", RegexOptions.None, timeout);

            textBox.Text = $"{minPart} - {maxPart}";

            if (minPart.Length > 0)
            {
                textBox.SelectionStart = minPart.Length + 3; 
            }
            else
            {
                textBox.SelectionStart = 0;
            }
        }


        private void txtBoxSalaryRange_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

            string[] parts = newText.Split('-');
            string minPart = parts.Length > 0 ? parts[0].Trim() : "";
            string maxPart = parts.Length > 1 ? parts[1].Trim() : "";

            if (minPart.Length + maxPart.Length >= 10)
            {
                e.Handled = true;
            }

            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9]+$");
        }

        private void txtBoxSalaryRange_Loaded(object sender, RoutedEventArgs e)
        {
            txtBoxSalaryRange.Text = " - "; 
        }

    }
}
