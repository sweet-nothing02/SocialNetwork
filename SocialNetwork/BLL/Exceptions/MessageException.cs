using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    public class MessageException : Exception
    {
        public string NewMessage { get; set; }
        public MessageException(string message)
        {
            NewMessage = $"При отправке сообщения произошла ошибка... ({message})";
        }
    }
}
