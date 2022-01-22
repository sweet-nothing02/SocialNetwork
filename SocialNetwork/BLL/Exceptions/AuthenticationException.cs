using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    public class AuthenticationException : Exception
    {
        public string NewMessage { get; set; }
        public AuthenticationException(string message)
        {
            NewMessage = $"При входе произошла ошибка... ({message})";
        }
    }
}
