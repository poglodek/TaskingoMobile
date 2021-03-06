using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskingoMobile.Models.Chat
{
    public class MessageModel
    {
        public string Sender { get; set; }
        public string UserMessage { get; set; }
        public override string ToString()
        {
            return $"{Sender}: {UserMessage}";
        }
    }
}
