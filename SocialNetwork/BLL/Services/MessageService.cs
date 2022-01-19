using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IMessageRepository messageRepository;

        public MessageService()
        {
            messageRepository = new MessageRepository();
        }

        public void SendMessage(MessageData messageData)
        {
            if (String.IsNullOrEmpty(messageData.Message))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(messageData.RecipientEmail))
                throw new ArgumentNullException();
            if (messageData.Message.Length > 5000)
                throw new Exception("Длина сообщения не должна быть больше 5000 символов");
            if (!new EmailAddressAttribute().IsValid(messageData.RecipientEmail))
                throw new Exception("Введен email неверного формата...");
            var recipient = new UserRepository();
            if (recipient.FindByEmail(messageData.RecipientEmail) == null)
                throw new Exception("Пользователь с введенным email не найден...");

            var messageEntity = new MessageEntity()
            {
                content = messageData.Message,
            }

        }
    }
}
