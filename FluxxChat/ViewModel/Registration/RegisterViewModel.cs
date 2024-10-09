using CommunityToolkit.Mvvm.ComponentModel;
using FluxxChat.View.Main;
using FluxxChat.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace FluxxChat.ViewModel.Registration
{
    public class RegisterViewModel : ObservableObject
    {
        private object _currentPage;
        public object CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        private int _selectedPageIndex;
        public int SelectedPageIndex
        {
            get { return _selectedPageIndex; }
            set { _selectedPageIndex = value; Navigate(); }
        }

        AutorizationPage _autorizationPage;
        RegisterPage _registerPage;

        public RegisterViewModel()
        {
            SelectedPageIndex = 0;
            _autorizationPage = new AutorizationPage(this); 
            _registerPage = new RegisterPage(this);
            Navigate();
        }

        void Navigate()
        {
            switch (SelectedPageIndex)
            {
                case 0:
                    CurrentPage = _autorizationPage;
                    break;
                case 1:
                    CurrentPage = _registerPage;
                    break;
            }
        }

        public void OpenAutorizationPage()
        {
            SelectedPageIndex = 0;
            Navigate();
        }

        public void OpenRegisterPage()
        {
            SelectedPageIndex = 1;
            Navigate();
        }

    }

}
