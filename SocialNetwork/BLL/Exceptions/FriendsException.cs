using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    public class FriendsException : Exception
    {
        public string NewMessage { get; set; }
        public FriendsException(string message)
        {
            NewMessage = $"При добавлении в друзья произошла ошибка... ({message})";
        }
    }
}
