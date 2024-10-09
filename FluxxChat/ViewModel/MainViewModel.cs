using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxxChat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FluxxChat.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        private ObservableCollection<Person> _PersonCollection; 
        private Person _selectedPerson;
        private string _textboxmessage;

        public ObservableCollection<Person> PersonCollection
        {
            get { return _PersonCollection; }
            set
            {
                _PersonCollection = value;
                OnPropertyChanged(nameof(PersonCollection));
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

        public string TextBoxMessage
        {
            get { return _textboxmessage; }
            set
            {
                _textboxmessage = value;
                OnPropertyChanged(nameof(TextBoxMessage));
            }
        }

        public MainViewModel()
        {
            PersonCollection = new ObservableCollection<Person> 
            { 
                new Person { Nickname = "Nickna", Status = "Делает крутой сайт", Avatar = "https://image.civitai.com/xG1nkqKTMzGDvpLrqFT7WA/ba8c4c7a-2544-4da4-8a5d-f996ea93b66c/width=1200/ba8c4c7a-2544-4da4-8a5d-f996ea93b66c.jpeg"},
                new Person { Nickname = "Outlow", Status = "Visual Studio 2017", Avatar = "https://ia800305.us.archive.org/31/items/discordprofilepictures/discordred.png"},
                new Person { Nickname = ".exe", Status = "Dota 2", Avatar = "https://images.genius.com/abf929ba95ac8de8f8fd67f6e6580611.1000x1000x1.png"},               
                new Person { Nickname = "Коля кабан", Status = "Решает вопросы", Avatar = "https://cdn.discordapp.com/attachments/1184109856492355674/1293323676317646960/spT7OlOcYJI.jpg?ex=6706f509&is=6705a389&hm=7e509cb8acc6be4607729ac9ef7a1761d04927db22ae3511026407c85188b769&"}           
            };

            SelectedPerson = PersonCollection.FirstOrDefault();
        }

        public ICommand SendMessageButton
        {
            get
            {
                return new RelayCommand(() => SendMessage());
            }
        }

        private void SendMessage()
        {
            if (TextBoxMessage != string.Empty)
            {
                SelectedPerson.AddNewMessage(TextBoxMessage, "Outlow");
                TextBoxMessage = string.Empty;
            }
        }
    }
}
