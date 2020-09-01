﻿using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            var сulture = CultureInfo.CreateSpecificCulture("ru");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages-ru.resx", typeof(Program).Assembly);

            Console.WriteLine(Languages.Messages_ru.HelloUser);
            Console.Write(Languages.Messages_ru.EnterNameUser);
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(Languages.Messages_ru.EnterGender);
                var gender = Console.ReadLine();
                var dateOfBirth = ParseDateTime();
                var weight = ParseDouble(Languages.Messages_ru.EnterWeight);
                var height = ParseDouble(Languages.Messages_ru.EnterHeight);

                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать ?");
            Console.Write("Е - Ввести приём пищи: ");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var proteins = ParseDouble("Белки");
            var fats = ParseDouble("Жиры");
            var carbohydrates = ParseDouble("Углеводы");
            var calories = ParseDouble("Калорийность");

            var weight = ParseDouble("Вес порции");
            var product = new Food(food, proteins, fats, carbohydrates, calories);

            return (Food: product, Weight: weight);
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
                    Console.WriteLine($"Неверный формат {name}a.");
                }
            }
        }
    }
}
