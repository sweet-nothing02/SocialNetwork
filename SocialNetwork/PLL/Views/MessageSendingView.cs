using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;

        public MessageSendingView(UserService userService, MessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.Write("Введите почтовый адрес получателя: ");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Введите сообщение (не более 5000 символов):");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;


            messageService.SendMessage(messageSendingData);

            SuccessMessage.Show("Сообщение успешно отправлено!");

            user = userService.FindById(user.Id);
            //try
            //{
            //    messageService.SendMessage(messageSendingData);

            //    SuccessMessage.Show("Сообщение успешно отправлено!");

            //    user = userService.FindById(user.Id);
            //}
            //catch (MessageException ex)
            //{
            //    AlertMessage.Show(ex.NewMessage);
            //}
            //catch(UserNotFoundException)
            //{
            //    AlertMessage.Show("Пользователь не найден...");
            //}
            //catch (Exception)
            //{
            //    AlertMessage.Show("Произошла ошибка...");
            //}
        }
    }
}
