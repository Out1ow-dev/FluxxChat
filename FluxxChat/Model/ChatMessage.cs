using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxxChat.Model
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
    }
}
