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
    public class FriendsService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendsService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddToFriends(FriendAddingData friendAddingData)
        {
            if (String.IsNullOrEmpty(friendAddingData.FriendEmail))
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(friendAddingData.FriendEmail))
                throw new ArgumentNullException();
            if (userRepository.FindByEmail(friendAddingData.FriendEmail) == null)
                throw new FriendsException("Пользователя с введенным email не существует...");
            if (GetFriendsByUserId(friendAddingData.UserId).Any(f => f.FriendEmail == friendAddingData.FriendEmail) == true)
                throw new FriendsException("Данный пользователь уже ваш друг!");

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddingData.UserId,
                friend_id = userRepository.FindByEmail(friendAddingData.FriendEmail).id
            };

            friendRepository.Create(friendEntity);
        }

        public void DeleteFromFriends(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentNullException();
            if (userRepository.FindByEmail(email) == null)
                throw new UserNotFoundException();

            friendRepository.Delete(userRepository.FindByEmail(email).id);
        }

        // Криво-косо получилось реализовать двухстороннее добавление в друзья
        public IEnumerable<Friend> GetFriendsByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                if (userRepository.FindById(f.user_id).email == userRepository.FindById(userId).email)
                {
                    friends.Add(new Friend(f.id, userRepository.FindById(f.user_id).email,
                        userRepository.FindById(f.friend_id).email));
                }
                if(userRepository.FindById(f.friend_id).email == userRepository.FindById(userId).email)
                {
                    friends.Add(new Friend(f.id, userRepository.FindById(f.friend_id).email,
                        userRepository.FindById(f.user_id).email));
                }
            }
            );
            
            return friends;
        }
    }
}
