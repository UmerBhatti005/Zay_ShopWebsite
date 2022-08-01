using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.Models
{
    public class Message
    {
        public Message(List<string> to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
