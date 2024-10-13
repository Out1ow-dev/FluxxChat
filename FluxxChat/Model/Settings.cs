using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxxChat.Model
{
    public static class Settings
    {
        public static event Action AvatarChanged;

        public static int id { get; set; }
        public static string Name { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        private static string _avatar;
        public static string Avatar
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
                AvatarChanged?.Invoke();
            }
        }

        public static Uri AvatarUri { get; set; }
    }

}
