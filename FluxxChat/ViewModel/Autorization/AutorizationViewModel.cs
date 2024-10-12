using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxxChat.Model;
using FluxxChat.ViewModel.HTTP;
using FluxxChat.ViewModel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.Controls;
using System.Net.Http.Headers;

namespace FluxxChat.ViewModel.Autorization
{
    public class AutorizationViewModel : ObservableObject
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


        public AutorizationViewModel(RegisterViewModel _registerViewModel) 
        {
            RegisterViewModel = _registerViewModel;            
        }

        public ICommand OpenRegisterPageCommand => new RelayCommand(OpenRegisterPage);
        public ICommand AuthorizationCommand => new RelayCommand(Authorization);

        private void OpenRegisterPage() 
        {
            RegisterViewModel.OpenRegisterPage();
        }

        private async void Authorization()
        {
            UserClient = new UserClient(Login, Password);
            var respond = await UserClient.AuthorizeUser();

            if (respond != null)
            {
                try
                {
                    Settings.id = respond.ID;
                    Settings.Login = respond.Login;
                    Settings.Name = respond.Name;
                    Settings.Password = respond.Password;
                    Settings.Avatar = respond.Uri;
                    RegisterViewModel.OpenMainPage();
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
