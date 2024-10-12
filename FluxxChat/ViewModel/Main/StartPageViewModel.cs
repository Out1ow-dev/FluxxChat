using CommunityToolkit.Mvvm.ComponentModel;
using FluxxChat.Model;
using FluxxChat.View;
using FluxxChat.View.Main;
using FluxxChat.View.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxxChat.ViewModel.Main
{
    public class StartPageViewModel : ObservableObject
    {
        private object _currentPage;
        public object CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); }
        }

        private MainPage mainPage;
        private RegisterMainPage registerPage;

        private int _selectedPageIndex;
        public int SelectedPageIndex
        {
            get { return _selectedPageIndex; }
            set { _selectedPageIndex = value; Navigate(); }
        }


        public StartPageViewModel()
        {
            if (Settings.id == null) 
            {
                SelectedPageIndex = 0;
            }
            else 
            {
                SelectedPageIndex = 1;
            }
            
            mainPage = new MainPage();
            registerPage = new RegisterMainPage();

            Navigate();
        }

        void Navigate()
        {
            switch (SelectedPageIndex)
            {
                case 0:
                    CurrentPage = mainPage;
                    break;
                case 1:
                    CurrentPage = registerPage;
                    break;
            }
        }
    }
}
