﻿using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using WorkFlex.Desktop.BusinessObject;
using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Desktop.DataAccess.Repositories;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
	{
		private readonly IUserRepository _userRepository;
		private readonly IServiceProvider _serviceProvider;
		public Login(IUserRepository userRepository, IServiceProvider serviceProvider)
		{
			InitializeComponent();
			_userRepository = userRepository;
			_serviceProvider = serviceProvider;
		}

		public void Clear()
		{
			EmailTextBox.Text = "";
			PasswordBox.Password = "";
			UserSession.Instance.Reset();
		}

		private async void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string email = EmailTextBox.Text;
				string password = PasswordBox.Password;
				var user = await _userRepository.GetByEmailAsync(email);
				if (user != null)
				{
					if (user.RoleId == 2 && !user.IsLock)
					{
						if (BCrypt.Net.BCrypt.Verify(password, user.Password))
						{
							UserSession.Instance.SetUser(AppMapper.Mapper.Map<UserDTO>(user));
                            var mainWindow = _serviceProvider.GetService<MainWindow>() ?? throw new Exception("MainWindow Service not found");
                            mainWindow.Show();
                            this.Hide();
						}
						else
						{
							MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
						}
					}
					else
					{
						MessageBox.Show("Your account does not have access to the system.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				else
				{
					MessageBox.Show("Login Error: ", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Login Error: " + ex.Message);
			}
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
