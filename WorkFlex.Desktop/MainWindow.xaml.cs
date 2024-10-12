using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using WorkFlex.Desktop.BusinessObject;
using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Desktop.BusinessObject.Service.Interface;
using WorkFlex.Desktop.DataAccess.Repositories;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private readonly IServiceProvider _serviceProvider;
		private readonly IJobPostService _jobPostService;

        public MainWindow(IServiceProvider serviceProvider, IJobPostService jobPostService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
			_jobPostService = jobPostService;
		}
        


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadJobs();

        }

        private void LoadJobs()
        {
            try
            {
                var jobs = _jobPostService.GetAllJobPosts();
                listView.ItemsSource = jobs;
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

            tbId.Clear();
            tbTitle.Clear();
            tbLocation.Clear();

            //listView.ItemsSource = jobs;
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            WindowJobCreate windowJobCreate = new WindowJobCreate(this,  _jobPostService);
            windowJobCreate.ShowDialog();
        }

        public void RefreshJobList()
        {
            listView.ItemsSource = _jobPostService.GetAllJobPosts();
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {

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
            catch (Exception ex)
            {
				MessageBox.Show("Logout Error: ", "Logout Failed", MessageBoxButton.OK, MessageBoxImage.Error);
			}
	    }
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
