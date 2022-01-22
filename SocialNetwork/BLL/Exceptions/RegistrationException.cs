using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    public class RegistrationException : Exception
    {
        public string NewMessage { get; set; }
        public RegistrationException(string message)
        {
            NewMessage = $"При регистрации произошла ошибка... ({message})";
        }
    }
}
