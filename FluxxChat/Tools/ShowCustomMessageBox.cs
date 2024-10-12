using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;

namespace FluxxChat.Tools
{
    internal static class ShowCustomMessageBox
    {
        public static void Show(string title, string text)
        {
            MessageBox messageBox = new MessageBox();
            messageBox.Width = 400;
            messageBox.Height = 250;
            messageBox.Title = title;
            messageBox.Content = text;
            messageBox.CloseButtonText = "Закрыть";
            messageBox.ShowDialogAsync();
        }
    }
}
