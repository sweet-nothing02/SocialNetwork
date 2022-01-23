using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
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

        public void Show(IEnumerable<Friend> friends, User user)
        {
            if(friends.Count() == 0)
            {
                Console.WriteLine("У вас пока нет друзей...");
                return;
            }

            Console.WriteLine("Мои друзья:");

            friends.ToList().ForEach(f =>
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
