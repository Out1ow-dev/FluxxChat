using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxxChat.Model
{
    public static class User
    {
        public static string NickName { get; set; } = string.Empty;

        public static string Identifier { get; set; } = string.Empty;

        private static string _avatar = string.Empty;
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
            }
        }

        public static Uri AvatarUri { get; private set; }
    }
}
