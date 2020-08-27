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

            Console.Write("Введите пол: ");
            var gender = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            var dateOfBirth = DateTime.Parse(Console.ReadLine()); // TODO: Переписать на TryParse

            Console.Write("Введите вес: ");
            var weight = double.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, dateOfBirth, weight, height);
            userController.Save();
        }
    }
}
