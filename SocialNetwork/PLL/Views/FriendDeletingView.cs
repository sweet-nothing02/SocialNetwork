using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
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

        }
    }
}
