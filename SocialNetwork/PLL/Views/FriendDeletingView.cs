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
    public class FriendDeletingView
    {
        FriendsService friendsService;
        UserService userService;

        public FriendDeletingView(FriendsService friendsService, UserService userService)
        {
            this.friendsService = friendsService;
            this.userService = userService;
        }
        public void Show(User user)
        {
            Console.Write("Введите email друга, которого хотите удалить: ");
            string email = Console.ReadLine();
            try
            {
                friendsService.DeleteFromFriends(email);
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введено значение неверного формата...");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден...");
            }
            catch(Exception)
            {
                AlertMessage.Show("Произошла ошибка");
            }
        }
    }
}
