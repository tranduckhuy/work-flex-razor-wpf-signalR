﻿using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WorkFlex.Desktop.BusinessObject;
using WorkFlex.Desktop.ViewModels;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
		private readonly IServiceProvider _serviceProvider;
		private readonly IJobService _jobService;

		public MainWindow(IServiceProvider serviceProvider, IJobService jobService)
        {
            InitializeComponent();
			_jobService = jobService;
            _serviceProvider = serviceProvider;

            DataContext = new JobListVM(_jobService);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var jobListVM = DataContext as JobListVM;
            jobListVM?.LoadJobs();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            var jobListVM = DataContext as JobListVM;
            jobListVM?.LoadJobs();
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            var jobListVM = DataContext as JobListVM;
            jobListVM?.LoadJobs();
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            var jobListVM = DataContext as JobListVM;
            jobListVM?.ClearFields();
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            WindowJobCreate windowJobCreate = new WindowJobCreate(this,  _jobService);
            windowJobCreate.ShowDialog();
        }

        private async void Button_Edit(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem is JobPostDto selectedJob)
            {
                var windowJobEdit = new WindowJobEdit(this, _jobService);
                var job = await _jobService.GetJobByIdAsync(selectedJob.Id);
                if (job != null)
                {
                    windowJobEdit.JobPostDto = selectedJob;
                    windowJobEdit.ShowDialog(); 
                } else
                {
                    MessageBox.Show(AppConstants.MESSAGE_JOB_NOT_FOUND, "Update Job", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No job selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem is JobPostDto selectedJob)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the job '{selectedJob.Title}'?", "Delete Job", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    var job = await _jobService.GetJobByIdAsync(selectedJob.Id);
                    if (job != null)
                    {
                        if (await _jobService.DeleteJobPostAsync(selectedJob.Id))
                        {
                            MessageBox.Show(AppConstants.MESSAGE_DELETE_JOB_SUCCESSFULLY, "Delete Job", MessageBoxButton.OK, MessageBoxImage.Information);
                            RefreshJobList();
                        } 
                        else
                        {
                            MessageBox.Show(AppConstants.MESSAGE_DELETE_JOB_FAILED, "Delete Job", MessageBoxButton.OK, MessageBoxImage.Error);
                            RefreshJobList();
                        }
                    } 
                    else
                    {
                        MessageBox.Show(AppConstants.MESSAGE_JOB_NOT_FOUND, "Delete Job", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("No job selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
		
        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					var login = _serviceProvider.GetRequiredService<Login>();
					login.Clear();
					login.Show();
					UserSession.Instance.Reset();
					Hide();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Logout Error: ", "Logout Failed", MessageBoxButton.OK, MessageBoxImage.Error);
			}
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            if (listView != null && gridView != null)
            {
                double width = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;

                if (width > 0)
                {
                    double column1 = 0.15; // Job Title
                    double column2 = 0.15; // Salary Range
                    double column3 = 0.15; // Job Location
                    double column4 = 0.25; // Job Description
                    double column5 = 0.15; // Created At
                    double column6 = 0.15; // Expired At

                    gridView.Columns[0].Width = width * column1;
                    gridView.Columns[1].Width = width * column2;
                    gridView.Columns[2].Width = width * column3;
                    gridView.Columns[3].Width = width * column4;
                    gridView.Columns[4].Width = width * column5;
                    gridView.Columns[5].Width = width * column6;

                }
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listView.SelectedItem is JobPostDto selectedJob)
            {
                if (selectedJob.Id != Guid.Empty)
                {
                    var jobDetailWindow = new JobDetail(selectedJob.Id, _jobService);
                    jobDetailWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Job ID is null or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("No job selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = listView.SelectedItem != null;
            btnDelete.IsEnabled = listView.SelectedItem != null;
        }

        public void RefreshJobList()
        {
        }
    }
}
