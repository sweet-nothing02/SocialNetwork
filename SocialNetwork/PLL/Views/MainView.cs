using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            SuccessMessage.Show("Здравствуйте, рады вас видеть!");
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Впервые здесь? Зарегистрируйтесь (нажмите 2)");
            AlertMessage.Show("Выйти (нажмите 3)");

            switch (Console.ReadLine())
            {
                case "1":
                    Program.authenticationView.Show();
                    break;
                case "2":
                    Program.registrationView.Show();
                    break;
                case "3":
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}
