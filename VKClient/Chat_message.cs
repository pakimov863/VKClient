using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKClient
{
    public enum MessageSide
    {
        Me,
        You
    }

    public class Chat_Message
    {
        public Chat_Message()
        {
            Timestamp = DateTime.Now;
        }
        public string Text { get; set; }

        public DateTime Timestamp { get; set; }

        public MessageSide Side { get; set; }

        public MessageSide PrevSide { get; set; }
    }
}
