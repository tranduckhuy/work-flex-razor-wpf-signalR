using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Infrastructure.Repositories;
using WorkFlex.Services;
using WorkFlex.Services.Interface;
using WorkFlex.Desktop.Mapping;
using Microsoft.Extensions.Logging;
using WorkFlex.Infrastructure.Utils.Helper.Interface;
using WorkFlex.Infrastructure.Utils.Helper;
using WorkFlex.Infrastructure.Utils.Mail;

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
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                    .Build();
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                // Sử dụng SQL Server và lấy chuỗi kết nối từ appsettings.json
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            serviceCollection.AddLogging(configure =>
            {
                configure.AddConsole();
                configure.AddDebug();
            });

            serviceCollection.AddAutoMapper(typeof(MappingProfile));

            serviceCollection.AddSingleton<IUserRepository, UserRepository>();
			serviceCollection.AddSingleton<IJobRepository, JobRepository>();
			serviceCollection.AddSingleton<IProfileRepository, ProfileRepository>();

            serviceCollection.AddScoped<IAuthenService, AuthenService>();
            serviceCollection.AddScoped<IJobService, JobService>();

			serviceCollection.AddTransient<Login>();
			serviceCollection.AddTransient<MainWindow>();

            // Helpers Register
            serviceCollection.AddScoped<IEmailHelper, EmailHelper>();

            serviceCollection.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            serviceCollection.AddTransient<SendMailUtil>();
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
