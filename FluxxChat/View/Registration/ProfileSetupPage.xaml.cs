using FluxxChat.ViewModel.Registration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FluxxChat.View.Registration
{
    /// <summary>
    /// Логика взаимодействия для ProfileSetupPage.xaml
    /// </summary>
    public partial class ProfileSetupPage : Page
    {
        public ProfileSetUpViewModel ViewModel { get; }

        public ProfileSetupPage(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            ViewModel = new ProfileSetUpViewModel(registerViewModel);
            DataContext = ViewModel;
        }
    }
}
