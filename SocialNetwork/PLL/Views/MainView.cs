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
            Console.WriteLine("Здравствуйте, рады вас видеть!");
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Впервые здесь? Зарегистрируйтесь (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    Program.authenticationView.Show();
                    break;
                case "2":
                    Program.registrationView.Show();
                    break;
            }
        }
    }
}
