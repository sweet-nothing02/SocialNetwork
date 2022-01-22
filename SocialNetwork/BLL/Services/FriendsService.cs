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
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                userId = friendAddingData.UserId,
                friendId = userRepository.FindByEmail(friendAddingData.FriendEmail).id
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

        public IEnumerable<Friend> GetFriendsByUserId(int user_id)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(user_id).ToList().ForEach(f =>
            friends.Add(new Friend(f.id, 
            userRepository.FindById(f.userId).email, userRepository.FindById(f.friendId).email)));
            
            return friends;
        }
    }
}
