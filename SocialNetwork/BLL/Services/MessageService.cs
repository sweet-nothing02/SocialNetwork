using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IMessageRepository messageReository;
        IUserRepository userRepository;

        public MessageService()
        {
            messageReository = new MessageRepository();
            userRepository = new UserRepository();
        }

        public void SendMessage(MessageSendingData messageSendingData)
        {
            if (String.IsNullOrEmpty(messageSendingData.RecipientEmail))
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(messageSendingData.RecipientEmail))
                throw new ArgumentNullException("Введен email неверного формата!");
            if (userRepository.FindByEmail(messageSendingData.RecipientEmail) == null)
                throw new ArgumentNullException("Пользователя с введенным email не существует!");
            if (String.IsNullOrEmpty(messageSendingData.Content))
                throw new ArgumentNullException();
            if (messageSendingData.Content.Length > 5000)
                throw new ArgumentNullException("Длина сообщения не должна превышать 5000 символов!");

            var messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                senderId = messageSendingData.SenderId,
                recipientId = userRepository.FindByEmail(messageSendingData.RecipientEmail).id
            };
        }
    }
}
