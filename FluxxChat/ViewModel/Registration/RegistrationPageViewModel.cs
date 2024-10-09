using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluxxChat.ViewModel.Registration
{
    public class RegistrationPageViewModel
    {
        private RegisterViewModel RegisterViewModel;

        public RegistrationPageViewModel(RegisterViewModel _registerViewModel)
        {
            RegisterViewModel = _registerViewModel;
        }

        public ICommand ReturnAutorizationPageCommand => new RelayCommand(ReturnAutorizationPage);

        private void ReturnAutorizationPage()
        {
            RegisterViewModel.OpenAutorizationPage();
        }
    }
}
