using Fitness.BL.Controller;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение AshFitness");
            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if(userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var dateOfBirth = ParseDateTime();
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");

                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        /// <summary>
        /// Парсер входного параметра типа DateTime
        /// </summary>
        /// <returns></returns>
        private static DateTime ParseDateTime()
        {
            DateTime dateOfBirth;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения.");
                }
            }

            return dateOfBirth;
        }

        /// <summary>
        /// Парсер входного параметра типа double
        /// </summary>
        /// <param name="name">String</param>
        /// <returns></returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}.");
                }
            }
        }
    }
}
