using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxxChat.ViewModel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluxxChat.ViewModel.Autorization
{
    public class AutorizationViewModel : ObservableObject
    {
        private RegisterViewModel RegisterViewModel;

        public AutorizationViewModel(RegisterViewModel _registerViewModel) 
        {
            RegisterViewModel = _registerViewModel;
        }

        public ICommand OpenRegisterPageCommand => new RelayCommand(OpenRegisterPage);

        private void OpenRegisterPage() 
        {
            RegisterViewModel.OpenRegisterPage();
        }
    }
}
