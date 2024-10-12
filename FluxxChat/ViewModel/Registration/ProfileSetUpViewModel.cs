using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluxxChat.ViewModel.Registration
{
    public class ProfileSetUpViewModel
    {
        private RegisterViewModel RegisterViewModel;

        public ProfileSetUpViewModel(RegisterViewModel _registerViewModel)
        {
            RegisterViewModel = _registerViewModel;
        }

        public ICommand OpenMainPageCommand => new RelayCommand(OpenMainPage);

        private void OpenMainPage()
        {
            RegisterViewModel.OpenMainPage();
        }
    }
}
