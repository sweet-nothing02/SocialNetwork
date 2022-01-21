using SocialNetwork.BLL.Exceptions;
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
        IMessageRepository messageRepository;
        IUserRepository userRepository;

        public MessageService()
        {
            messageRepository = new MessageRepository();
            userRepository = new UserRepository();
        }

        public void SendMessage(MessageSendingData messageSendingData)
        {
            if (String.IsNullOrEmpty(messageSendingData.RecipientEmail))
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(messageSendingData.RecipientEmail))
                throw new ArgumentNullException();
            if (userRepository.FindByEmail(messageSendingData.RecipientEmail) == null)
                throw new UserNotFoundException();
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

            messageRepository.Create(messageEntity);
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipient_Id)
        {
            var messages = new List<Message>();

            messageRepository.FindByRecipientId(recipient_Id).ToList().ForEach(m =>
            {
                messages.Add(new Message(m.id, m.content,
                    userRepository.FindById(m.senderId).email, userRepository.FindById(m.recipientId).email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int sender_id)
        {
            var messages = new List<Message>();

            messageRepository.FindBySenderId(sender_id).ToList().ForEach(m =>
            {
                messages.Add(new Message(m.id, m.content,
                    userRepository.FindById(m.senderId).email, userRepository.FindById(m.recipientId).email));
            });

            return messages;
        }
    }
}
