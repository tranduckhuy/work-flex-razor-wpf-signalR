using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WorkFlex.Desktop.BusinessObject;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Filters;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter!);
        }

        public void Execute(object? parameter) { _execute(parameter!); }
    }

    public partial class MainWindow : Window
    {
		private readonly IServiceProvider _serviceProvider;
		private readonly IJobService _jobService;

		private IEnumerable<JobPostDto> Jobs { get; set; } = new List<JobPostDto>();

		private int TotalCount { get; set; }

        private int _currentPage = 1;
        private int _pageSize = 20;

        public event PropertyChangedEventHandler PropertyChanged = null!;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); LoadJobs(); }
        }

        public ICommand NextPageCommand { get; }

        public ICommand PreviousPageCommand { get; }

		public MainWindow(IServiceProvider serviceProvider, IJobService jobService)
        {
            InitializeComponent();
			_jobService = jobService;
            _serviceProvider = serviceProvider;

            NextPageCommand = new RelayCommand(_ => CurrentPage++, _ => CurrentPage < ((double)TotalCount / _pageSize));
            PreviousPageCommand = new RelayCommand(_ => CurrentPage--, _ => CurrentPage > 1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadJobs();
        }

        private async void LoadJobs()
        {
            try
            {
                // Filter Job Type
                var jobTypesData = await _jobService.GetJobTypesAsync();
                var jobTypes = jobTypesData.Select(jt => jt.TypeName).ToList();
                cbType.ItemsSource = jobTypes;

                // Filter Posted Within
                cbPostedWithin.ItemsSource = new List<string> { "Any", "Today", "Last 2 days", "Last 3 days", "Last 5 days", "Last 10 days" };

                // Filter Sort By
                cbSortBy.ItemsSource = new List<string> { "None", "SalaryLowToHigh", "SalaryHighToLow" };

                // Create filter for searching
                JobFilter filter = new JobFilter
                {
                    JobLocation = !string.IsNullOrEmpty(tbLocation.Text) ? tbLocation.Text : string.Empty,
                    JobType = !string.IsNullOrEmpty((string)cbType.SelectedValue) ? (string)cbType.SelectedValue : string.Empty,
                    PostedWithin = !string.IsNullOrEmpty((string)cbPostedWithin.SelectedValue) ? (string)cbPostedWithin.SelectedValue : string.Empty,
                    MinSalary = !string.IsNullOrEmpty(tbMinSalary.Text) ? decimal.Parse(tbMinSalary.Text) : 0,
                    MaxSalary = !string.IsNullOrEmpty(tbMaxSalary.Text) ? decimal.Parse(tbMaxSalary.Text) : 0,
                    SortBy = !string.IsNullOrEmpty((string)cbSortBy.SelectedValue) ? (string)cbSortBy.SelectedValue : string.Empty,
                    PageNumber = CurrentPage,
                    PageSize = _pageSize,
                };

                (Jobs, TotalCount) = await _jobService.GetJobsAsync(filter);
                listView.ItemsSource = Jobs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading jobs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    //double column1 = 0.05; // Job Id
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
                    //gridView.Columns[6].Width = width * column7;
                }
            }
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {

            tbLocation.Clear();
            tbMinSalary.Clear();
            tbMaxSalary.Clear();

            cbType.SelectedIndex = -1;
            cbPostedWithin.SelectedIndex = -1;
            cbSortBy.SelectedIndex = -1;
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            WindowJobCreate windowJobCreate = new WindowJobCreate(this,  _jobService);
            windowJobCreate.ShowDialog();
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            LoadJobs();
        }

        public void RefreshJobList()
        {
            LoadJobs();
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            LoadJobs();
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

        private void Window_Closing(object sender, CancelEventArgs e)
		{
			Application.Current.Shutdown();
		}
    }
}
