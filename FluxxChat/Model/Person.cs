using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxxChat.Model
{
    public class Person : ObservableObject
    {
        public string Nickname { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }

        private string _avatar;
        public string Avatar
        {
            get { return _avatar; }
            set
            {
                _avatar = value;
                Uri avatarUri;
                if (Uri.TryCreate(value, UriKind.Absolute, out avatarUri))
                {
                    AvatarUri = avatarUri;
                }
                else
                {
                    AvatarUri = null;
                }
            }
        }

        public Uri AvatarUri { get; private set; }

        private ObservableCollection<ChatMessage> _Messages;
        public ObservableCollection<ChatMessage> Messages
        {
            get { return _Messages; }
            set
            {
                _Messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }

        public void InitMessages()
        {
            Messages = new ObservableCollection<ChatMessage>();
        }

        public void AddNewMessage(string message, string sender)
        {
            if (Messages == null)
            {
                Messages = new ObservableCollection<ChatMessage>();
            }
            Messages.Add(new ChatMessage { Message = message, Sender = sender, Timestamp = DateTime.Now.ToString("hh:mm:ss") });
        }
    }

}
