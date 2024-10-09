using FluxxChat.ViewModel.Autorization;
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
using System.Windows.Shapes;

namespace FluxxChat.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage 
    {
        public RegistrationPageViewModel ViewModel { get; }

        public RegisterPage(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            ViewModel = new RegistrationPageViewModel(registerViewModel);
            DataContext = ViewModel;
        }
    }
}
