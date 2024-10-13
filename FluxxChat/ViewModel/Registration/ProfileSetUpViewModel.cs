using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxxChat.Model;
using FluxxChat.ViewModel.HTTP;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace FluxxChat.ViewModel.Registration
{
    public class ProfileSetUpViewModel : ObservableObject
    {
        private RegisterViewModel RegisterViewModel;
        private UserClient userClient;
        private string _imageSource = "/Resources/Images/StandartAvatar.png";
        public string ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged(nameof(ImageSource)); 
                }
            }
        }

        public ProfileSetUpViewModel(RegisterViewModel _registerViewModel)
        {
            RegisterViewModel = _registerViewModel;
        }

        public ICommand OpenMainPageCommand => new RelayCommand(OpenMainPage);
        public ICommand SetImageCommand => new RelayCommand(SetImage);

        private async void OpenMainPage()
        {
            if (ImageSource != null && !ImageSource.Contains("StandartAvatar.png")) 
            {
                userClient = new UserClient(Settings.Login, Settings.Password);
                Settings.Avatar = await userClient.UploadAvatar(ImageSource);
            }
            RegisterViewModel.OpenMainPage();
        }

        private void SetImage()
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageSource = openFileDialog.FileName;
                }
            }
        }
    }
}
