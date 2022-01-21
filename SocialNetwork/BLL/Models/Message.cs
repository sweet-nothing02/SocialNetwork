using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Message
    {
        public int Id { get; }
        public string Content { get; }
        public string SenderEmail { get; }
        public string RecipientEmail { get; }

        public Message(int id, string content, string senderEmail, string recipientEmail)
        {
            Id = id;
            Content = content;
            SenderEmail = senderEmail;
            RecipientEmail = recipientEmail;
        }
    }
}
