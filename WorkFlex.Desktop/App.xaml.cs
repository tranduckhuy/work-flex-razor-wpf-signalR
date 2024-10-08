using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WorkFlex.Desktop.DataAccess.Repositories;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private IServiceProvider _serviceProvider = null!;
		public App()
		{
			ServiceCollection serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			_serviceProvider = serviceCollection.BuildServiceProvider();
		}

		private static void ConfigureServices(ServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<IUserRepository, UserRepository>();
			serviceCollection.AddTransient<Login>();
			serviceCollection.AddTransient<MainWindow>();
		}

		protected void OnStartup(object sender, StartupEventArgs e)
		{
			var login = _serviceProvider.GetRequiredService<Login>();
			login.Show();
		}
	}

}
