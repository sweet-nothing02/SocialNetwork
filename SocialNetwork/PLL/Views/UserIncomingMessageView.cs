using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserIncomingMessageView
    {
        public void Show(IEnumerable<Message> incomingMessages)
        {
            if (incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих сообщений сообщений нет...");
                System.Threading.Thread.Sleep(3000);
                return;
            }

            Console.WriteLine("Входящие сообщения: ");

            incomingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine($"От кого: {m.SenderEmail}");
                Console.WriteLine($"Текст сообщения: {m.Content}");
                Console.WriteLine("-----------------------------");
            });
        }
    }
}
