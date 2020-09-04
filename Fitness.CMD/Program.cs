using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            var сulture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);
        
            Console.WriteLine(resourceManager.GetString("HelloUser", сulture)); 
            Console.Write(resourceManager.GetString("EnterNameUser", сulture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", сulture));
                var gender = Console.ReadLine();
                var dateOfBirth = ParseDateTime("дата рождения");
                var weight = ParseDouble(resourceManager.GetString("EnterWeight", сulture));
                var height = ParseDouble(resourceManager.GetString("EnterHeight", сulture));

                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("Что вы хотите сделать ?");
                Console.Write("Е - Ввести приём пищи.");
                Console.Write("A - Ввести упражнение.");
                Console.WriteLine("Q - выход.");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exer = EnterExercise();
                        exerciseController.AddExercise(exer.Activity, exer.Start, exer.Finish);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} да {item.Finish.ToShortTimeString()}");
                        }

                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Start, DateTime Finish, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var start = ParseDateTime("начало упражнения");
            var finish = ParseDateTime("окончание упражнения");
            var activity = new Activity(name, energy);

            return (start, finish, activity);
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
        private static DateTime ParseDateTime(string value)
        {
            DateTime dateOfBirth;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
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
