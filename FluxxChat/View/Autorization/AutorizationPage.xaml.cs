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
using Wpf.Ui.Controls;

namespace FluxxChat.View
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage 
    {
        public AutorizationViewModel ViewModel { get; }

        public AutorizationPage(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            ViewModel = new AutorizationViewModel(registerViewModel);
            DataContext = ViewModel;
        }
    }
}
