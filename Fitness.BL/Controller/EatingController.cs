using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Добавление еды и получение продукта из списка
    /// </summary>
    public class EatingController
    {
        private readonly User user;

        /// <summary>
        /// Список продуктов
        /// </summary>
        public List<Food> Foods { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("The user can't be null", nameof(user));
            Foods = GetAllFoods();
        }

        /// <summary>
        /// Получение полного списка продуктов из файла
        /// </summary>
        /// <returns>new List<Food>()</returns>
        private List<Food> GetAllFoods()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("foods.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<Food> foods)
                {
                    return foods;
                }
                else
                {
                    return new List<Food>();
                }
            }
        }
    }
}
