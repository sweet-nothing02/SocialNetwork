using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class MessageData
    {
        public string Message { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string SenderEmail { get; set; }
        public string RecipientEmail { get; set; }
    }
}
