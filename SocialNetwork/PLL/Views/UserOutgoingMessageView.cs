using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserOutgoingMessageView
    {
        public void Show(IEnumerable<Message> outgoingMessages)
        {
            if (outgoingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений  нет...");
                System.Threading.Thread.Sleep(3000);
                return;
            }

            Console.WriteLine("Исходящие сообщения: ");

            outgoingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine($"Кому: {m.SenderEmail}");
                Console.WriteLine($"Текст сообщения: {m.Content}");
                Console.WriteLine("-----------------------------");
            });
        }
    }
}
