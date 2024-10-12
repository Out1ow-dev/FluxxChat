using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxxChat.Model
{
    public class User
    {
        public int ID { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public Uri Uri { get; set; }
    }
}
