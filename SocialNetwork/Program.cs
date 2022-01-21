using System;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть!");

            while (true)
            {
                Console.WriteLine("Войти в социальную сеть: нажмите 1");
                Console.WriteLine("Вы здесь впервые? Зарегистрируйтесь, нажав 2");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            var authenticationData = new UserAuthenticationData();

                            Console.Write("Введите почтовый адрес: ");
                            authenticationData.Email = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            authenticationData.Password = Console.ReadLine();

                            try
                            {
                                User user = userService.Authenticate(authenticationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Вы успешно вошли в сеть! Добро пожаловать, {user.FirstName}");
                                Console.ResetColor();

                                while (true)
                                {
                                    Console.WriteLine("Посмотреть мой профиль (нажмите 1)");
                                    Console.WriteLine("Редактировать профиль (нажмите 2)");
                                    Console.WriteLine("Добавить в друзья (нажмите 3)");
                                    Console.WriteLine("Написать сообщение (нажмите 4)");
                                    Console.WriteLine("Выйти из профиля (нажмите 5)");
                                    Console.WriteLine("Посмотреть информацию о профиле (нажмите 6)");

                                    switch (Console.ReadLine())
                                    {

                                    }
                                }

                            }
                            catch
                            {

                            }
                        }

                }
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
