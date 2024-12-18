﻿using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Desktop.BusinessObject;
using WorkFlex.Services.Interface;
using WorkFlex.Services.DTOs;

namespace WorkFlex.Desktop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAuthenService _authenService;
        private readonly IServiceProvider _serviceProvider;


        public Login(IAuthenService authenService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authenService = authenService;
            _serviceProvider = serviceProvider;
        }

        public void Clear()
        {
            tbUsername.Text = "";
            pwdBox.Password = "";
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>() ?? throw new InvalidOperationException("MainWindow service not found");
            string username = tbUsername.Text;
            string password = pwdBox.Password;
            var userSession = UserSession.Instance.GetUser();
            if (userSession != null && userSession.Username == username)
            {
                Hide();
                mainWindow.Show();
            }

            try
            {
                LoginReqDto req = new LoginReqDto
                {
                    Username = username,
                    Password = password
                };

                var loginResDto = await _authenService.CheckLoginAsync(req);
                if (loginResDto == null)
                {
                    MessageBox.Show(AppConstants.MESSAGE_FAILED, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                switch (loginResDto!.Result)
                {
                    case AppConstants.LoginResult.Success:
                        if (loginResDto.User != null)
                        {
                            if (loginResDto.User.RoleId != 2)
                            {
                                MessageBox.Show(AppConstants.MESSAGE_UNAUTHORIZED, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            Hide();
                            Clear();
                            mainWindow.Show();
                            UserSession.Instance.SetUser(loginResDto.User);
                        }
                        break;
                    case AppConstants.LoginResult.UserNotFound:
                        MessageBox.Show(AppConstants.MESSAGE_INVALID_USERNAME, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case AppConstants.LoginResult.InvalidPassword:
                        MessageBox.Show(AppConstants.MESSAGE_INVALID_PASSWORD, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case AppConstants.LoginResult.AccountLocked:
                        MessageBox.Show(AppConstants.MESSAGE_ACCOUNT_LOCKED, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case AppConstants.LoginResult.AccountInactive:
                        MessageBox.Show(AppConstants.MESSAGE_ACCOUNT_INACTIVE, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    default:
                        MessageBox.Show(AppConstants.MESSAGE_FAILED, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            catch
            {
                Clear();
                UserSession.Instance.Reset();
                MessageBox.Show(AppConstants.MESSAGE_FAILED, AppConstants.MESSAGE_LOGIN_FAILED, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
