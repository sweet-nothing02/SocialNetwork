using System;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Добро пожаловать в социальную сеть!");
                try
                {
                    Console.WriteLine("Для регистрации введите имя: ");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Введите фамилию: ");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("Введите пароль: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Введите email: ");
                    string email = Console.ReadLine();

                    UserRegistrationData userData = new UserRegistrationData()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Password = password,
                        Email = email
                    };

                    UserService service = new UserService();
                    service.Register(userData);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

        }
    }
}
