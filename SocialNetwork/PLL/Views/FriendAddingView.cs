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
    public class FriendAddingView
    {
        FriendsService friendsService;
        UserService userService;

        public FriendAddingView(FriendsService friendsService, UserService userService)
        {
            this.friendsService = friendsService;
            this.userService = userService;
        }
        public void Show(User user)
        {
            var friendAddingData = new FriendAddingData();

            Console.Write("Введите email пользователя, которого хотите добавить в друзья: ");
            friendAddingData.FriendEmail = Console.ReadLine();

            friendAddingData.UserId = user.Id;

            try
            {
                friendsService.AddToFriends(friendAddingData);

                SuccessMessage.Show($"Пользователь с почтовым адресом {friendAddingData.FriendEmail} добавлен в друзья");

                user = userService.FindById(user.Id);
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введено значение неверного формата...");
            }
            catch (FriendsException ex)
            {
                AlertMessage.Show(ex.NewMessage);
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла неизвестная ошибка...");
            }
        }
    }
}
