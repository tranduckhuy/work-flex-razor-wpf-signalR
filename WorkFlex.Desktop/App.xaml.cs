using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;
using WorkFlex.Desktop.BusinessObject.Service;
using WorkFlex.Desktop.BusinessObject.Service.Interface;
using WorkFlex.Desktop.DataAccess.Repositories;
using WorkFlex.Desktop.DataAccess.Repositories.Interface;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private readonly IServiceProvider _serviceProvider;
		public App()
		{
			ServiceCollection serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			_serviceProvider = serviceCollection.BuildServiceProvider();
		}

		private static void ConfigureServices(ServiceCollection serviceCollection)
		{
            // Đăng ký AppDbContext với container DI
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                // Sử dụng SQL Server và lấy chuỗi kết nối từ appsettings.json
                var configuration = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                        .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            serviceCollection.AddSingleton<IUserRepository, UserRepository>();
			serviceCollection.AddSingleton<IJobRepository, JobRepository>();
            serviceCollection.AddScoped<IJobPostService, JobPostService>();
            serviceCollection.AddTransient<Login>();
			serviceCollection.AddTransient<MainWindow>();
		}

		protected void OnStartup(object sender, StartupEventArgs e)
		{
			var login = _serviceProvider.GetRequiredService<Login>();
			login.Show();
		}

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }

}
