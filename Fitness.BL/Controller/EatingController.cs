using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Добавление еды и получение продукта из списка
    /// </summary>
    public class EatingController : ControllerBase<Eating>
    {
        /// <summary>
        /// Константа имя файла продуктов
        /// </summary>
        private const string FOODS_FILE_NAME = "foods.dat";

        /// <summary>
        /// Константа имя файла съеденных продуктов
        /// </summary>
        private const string EATING_FILE_NAME = "eating.dat";

        /// <summary>
        /// Приватная переменная типа User
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список продуктов
        /// </summary>
        public List<Food> Foods { get; }

        /// <summary>
        /// Список съеденных продуктов
        /// </summary>
        public Eating Eating { get; }

        /// <summary>
        /// Если пользователь не null получаем полный список продуктов с принадлежностью к пользователю
        /// </summary>
        /// <param name="user">Пользователь</param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("The user can't be null", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Метод добавления еды, если такого продукта нет было ранее, то добавляем новый.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="calorie"></param>
        public void Add(Food food, double calorie)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, calorie);
                Save();
            }
            else
            {
                Eating.Add(product, calorie);
                Save();
            }
        }

        /// <summary>
        /// Справочник приёмов пищи
        /// </summary>
        /// <returns></returns>
        private Eating GetEating()
        {
            return Load().First();
        }

        /// <summary>
        /// Справочник продуктов. Получение полного списка продуктов из файла
        /// </summary>
        /// <returns>new List<Food>()</returns>
        private List<Food> GetAllFoods()
        {
            return Load();
        }

        /// <summary>
        /// Сохраняем наш список продуктов
        /// </summary>
        private void Save()
        {
            Save();
        }
    }
}
