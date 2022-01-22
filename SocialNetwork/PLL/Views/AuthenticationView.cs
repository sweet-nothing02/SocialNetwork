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
    public class AuthenticationView
    {
        UserService userService;

        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.Write("Введите почтовый адрес: ");
            authenticationData.Email = Console.ReadLine();
            Console.Write("Введите пароль: ");
            authenticationData.Password = Console.ReadLine();

            var user = this.userService.Authenticate(authenticationData);

            SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
            SuccessMessage.Show($"Добро пожаловать, {user.FirstName}");

            Program.userMenuView.Show(user);
            //try
            //{
            //    var user = this.userService.Authenticate(authenticationData);

            //    SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
            //    SuccessMessage.Show($"Добро пожаловать, {user.FirstName}");

            //    Program.userMenuView.Show(user);
            //}
            //catch(AuthenticationException ex)
            //{
            //    AlertMessage.Show(ex.NewMessage);
            //}
            //catch (Exception)
            //{
            //    AlertMessage.Show("Произошла неизвестная ошибка...");
            //}
        }
    }
}
