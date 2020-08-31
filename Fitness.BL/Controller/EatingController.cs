﻿using Fitness.BL.Model;
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
    public class EatingController : ControllerBase
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
        public List<Eating> Eatings { get; }

        /// <summary>
        /// Если пользователь не null получаем полный список продуктов с принадлежностью к пользователю
        /// </summary>
        /// <param name="user">Пользователь</param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("The user can't be null", nameof(user));
            Foods = GetAllFoods();
            Eatings = GetAllEatings();
        }

        /// <summary>
        /// Метод добавления еды
        /// </summary>
        /// <param name="foodName">Имя продукта</param>
        /// <param name="calorie">Количество еды (калорий)</param>
        public void Add(string foodName, double calorie)
        {
            var food = Foods.SingleOrDefault(f => f.Name == foodName);
        }

        /// <summary>
        /// Справочник приёмов пищи
        /// </summary>
        /// <returns></returns>
        private List<Eating> GetAllEatings()
        {
            return Load<List<Eating>>(EATING_FILE_NAME) ?? new List<Eating>();
        }

        /// <summary>
        /// Справочник продуктов. Получение полного списка продуктов из файла
        /// </summary>
        /// <returns>new List<Food>()</returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        /// <summary>
        /// Сохраняем наш список продуктов
        /// </summary>
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eatings);
        }
    }
}
