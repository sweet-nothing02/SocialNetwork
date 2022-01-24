using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
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
                InfoMessage.Show("Входящих сообщений сообщений нет...");
                System.Threading.Thread.Sleep(3000);
                return;
            }

            InfoMessage.Show("Входящие сообщения: ");

            incomingMessages.ToList().ForEach(m =>
            {
                Console.WriteLine($"От кого: {m.SenderEmail}");
                Console.WriteLine($"Текст сообщения: {m.Content}");
                Console.WriteLine("-----------------------------");
            });
        }
    }
}
