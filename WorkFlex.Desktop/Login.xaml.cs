﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkFlex.Desktop.BusinessObject;
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
				var user = await _userRepository.GetByEmailAndPasswordAsync(email, password);
				if (user != null)
				{
					if (user.RoleId == 1 || user.RoleId == 2)
					{
						UserSession.Instance.SetUser(AppMapper.Mapper.Map<UserObject>(user));
						var mainWindow = _serviceProvider.GetService<MainWindow>() ?? throw new Exception("MainWindow Service not found");
						mainWindow.Show();
						this.Hide();
					}
					else
					{
						MessageBox.Show("Your account does not have access to the system.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				else
				{
					MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
