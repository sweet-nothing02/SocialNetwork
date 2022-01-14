using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities
{
    public class MessageEntity
    {
        public int id { get; set; }
        public string content { get; set; }
        public int senderId { get; set; }
        public int recipientId { get; set; }
    }
}
