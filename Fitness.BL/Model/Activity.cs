﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Класс активности, включает в себя: Наименование активности, кол-во с жженых калорий.
    /// </summary>
    [Serializable]
    public class Activity
    {
        /// <summary>
        /// Идентификаторы для EntityFramework
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название активности
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Связывающие поля для коллекции
        /// </summary>
        public virtual ICollection<Exercise> Exercise { get; set; }

        /// <summary>
        /// Количество сжигаемых калорий на единицу времени
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        public Activity() { }

        /// <summary>
        /// Конструктор инициализации активности
        /// </summary>
        /// <param name="name">Название активности</param>
        /// <param name="caloriesPerMinute">Кол-во с жженных калорий в минуту</param>
        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of user can not be null or with white space");
            }

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        /// <summary>
        /// Пересоздали ToString() метод  
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Активность: {Name}, Уничтожено кКал в минуту: {CaloriesPerMinute}";
        }
    }
}
