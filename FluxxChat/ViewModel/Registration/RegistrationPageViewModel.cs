using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxxChat.Model;
using FluxxChat.ViewModel.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluxxChat.ViewModel.Registration
{
    public class RegistrationPageViewModel : ObservableObject
    {
        private RegisterViewModel RegisterViewModel;
        private UserClient UserClient;
        private string _login;
        private string _password;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public RegistrationPageViewModel(RegisterViewModel _registerViewModel)
        {
            RegisterViewModel = _registerViewModel;
        }

        public ICommand ReturnAutorizationPageCommand => new RelayCommand(ReturnAutorizationPage);
        public ICommand OpenSetUpPageCommand => new RelayCommand(OpenSetUpPage);
        public ICommand RegistrationCommand => new RelayCommand(Registration);

        private void ReturnAutorizationPage()
        {
            RegisterViewModel.OpenAutorizationPage();
        }

        private void OpenSetUpPage()
        {
            RegisterViewModel.OpenSetUpPage();
        }

        private async void Registration()
        {
            UserClient = new UserClient(Login, Password);
            var respond = await UserClient.RegisterUser();

            if (respond != null)
            {
                try
                {
                    Settings.id = respond.ID;
                    Settings.Login = respond.Login;
                    Settings.Name = respond.Name;
                    Settings.Password = respond.Password;
                    Settings.Avatar = respond.Uri.ToString();
                    OpenSetUpPage();
                }
                catch
                {

                }
            }
            else
            {

            }
        }
    }
}
