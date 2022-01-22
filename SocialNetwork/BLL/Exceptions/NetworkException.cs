using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    public class NetworkException : Exception
    {
        public string NewMessage { get; set; }

        public NetworkException(string message)
        {
            NewMessage = message;
        }
    }
}
