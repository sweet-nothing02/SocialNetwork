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
    public class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для создания нового профиля введите ваше имя:");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Введите пароль (не менее 8 символов): ");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Введите ваш email: ");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                this.userService.Register(userRegistrationData);

                SuccessMessage.Show("Ваш профиль успешно создан. Теперь вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введеное значение не должно быть пустым!");
            }
            catch(RegistrationException ex)
            {
                AlertMessage.Show(ex.NewMessage);
            }
            catch(Exception)
            {
                AlertMessage.Show("Произошла неизвестная ошибка...");
            }
        }
    }
}
