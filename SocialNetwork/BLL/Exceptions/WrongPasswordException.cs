using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    public class WrongPasswordException : NetworkException
    {
        public WrongPasswordException(string message) : base(message)
        {
            NewMessage = String.Concat("Произошла ошибка... ", message);
        }
    }
}
