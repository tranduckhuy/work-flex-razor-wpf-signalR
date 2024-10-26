using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WorkFlex.Domain.Filters;
using WorkFlex.Services.DTOs;
using WorkFlex.Services.Interface;

namespace WorkFlex.Desktop.ViewModels
{
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
            return _canExecute == null || _canExecute(parameter!);
        }

        public void Execute(object? parameter) { _execute(parameter!); }
    }

    public class JobListVM : INotifyPropertyChanged
    {

        private int _currentPage = 1;
        private readonly int _pageSize = 10;

        private string? _location;
        private string? _selectedJobType;
        private string? _selectedPostedWithin;
        private string? _selectedSortBy;
        private decimal? _minSalary = 0;
        private decimal? _maxSalary = 0;

        public string? Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged(nameof(Location)); }
        }

        public string? SelectedJobType
        {
            get => _selectedJobType;
            set { _selectedJobType = value; OnPropertyChanged(nameof(SelectedJobType)); }
        }

        public string? SelectedPostedWithin
        {
            get => _selectedPostedWithin;
            set { _selectedPostedWithin = value; OnPropertyChanged(nameof(SelectedPostedWithin)); }
        }

        public string? SelectedSortBy
        {
            get => _selectedSortBy;
            set { _selectedSortBy = value; OnPropertyChanged(nameof(SelectedSortBy)); }
        }

        public decimal? MinSalary
        {
            get => _minSalary;
            set { _minSalary = value; OnPropertyChanged(nameof(MinSalary)); }
        }

        public decimal? MaxSalary
        {
            get => _maxSalary;
            set { _maxSalary = value; OnPropertyChanged(nameof(MaxSalary)); }
        }

        // Thuộc tính CurrentPage đã có sẵn
        public int CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); LoadJobs(); }
        }

        // Command cho việc chuyển trang
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        private readonly IJobService _jobService;

        public JobListVM(IJobService jobService)
        {
            _jobService = jobService;

            NextPageCommand = new RelayCommand(_ => CurrentPage++, _ => CurrentPage < Math.Ceiling((double)TotalCount / _pageSize));
            PreviousPageCommand = new RelayCommand(_ => CurrentPage--, _ => CurrentPage > 1);
        }

        public async void LoadJobs()
        {
            try
            {
                var jobTypesData = await _jobService.GetJobTypesAsync();
                JobTypes = ["All", .. jobTypesData.Select(jt => jt.TypeName)];
                OnPropertyChanged(nameof(JobTypes));

                JobFilter filter = new JobFilter
                {
                    JobLocation = Location,
                    JobType = SelectedJobType,
                    PostedWithin = SelectedPostedWithin,
                    MinSalary = MinSalary,
                    MaxSalary = MaxSalary,
                    SortBy = SelectedSortBy,
                    PageNumber = _currentPage,
                    PageSize = _pageSize,
                };
                
                (Jobs, TotalCount, TotalPages) = await _jobService.GetJobsAsync(filter);
                OnPropertyChanged(nameof(Jobs));
                OnPropertyChanged(nameof(PreviousPageCommand));
                OnPropertyChanged(nameof(NextPageCommand));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading jobs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ClearFields()
        {
            Location = string.Empty;
            SelectedJobType = null;
            SelectedPostedWithin = null;
            MinSalary = 0;
            MaxSalary = 0;
            SelectedSortBy = null;

            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(SelectedJobType));
            OnPropertyChanged(nameof(SelectedPostedWithin));
            OnPropertyChanged(nameof(MinSalary));
            OnPropertyChanged(nameof(MaxSalary));
            OnPropertyChanged(nameof(SelectedSortBy));
            OnPropertyChanged(nameof(PreviousPageCommand));
            OnPropertyChanged(nameof(NextPageCommand));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<JobPostDto> Jobs { get; set; } = new List<JobPostDto>();
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<string>? JobTypes { get; set; }
        public List<string> PostedWithinOptions { get; set; } = new List<string> { "Any", "Today", "Last 2 days", "Last 3 days", "Last 5 days", "Last 10 days" };
        public List<string> SortByOptions { get; set; } = new List<string> { "None", "SalaryLowToHigh", "SalaryHighToLow" };
    }

}
