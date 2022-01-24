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
    public class FriendsView
    {
        FriendsService friendsService;
        UserService userService;

        public FriendsView(FriendsService friendsService, UserService userService)
        {
            this.friendsService = friendsService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            if(user.Friends.Count() == 0)
            {
                InfoMessage.Show("У вас пока нет друзей...");
                return;
            }

            InfoMessage.Show("Мои друзья:");
            user.Friends.ToList().ForEach(f =>
            {
                var fr = userService.FindByEmail(f.FriendEmail);
                Console.WriteLine($"{fr.FirstName} {fr.LastName}, {fr.Email}");
            });

            Console.WriteLine();
            Console.WriteLine("Удалить друга (нажмите 1)");
            Console.WriteLine("Выйти (любая другая клавиша)");
            if (Console.ReadLine() == "1")
                Program.friendDeletingView.Show(user);
        }
    }
}
