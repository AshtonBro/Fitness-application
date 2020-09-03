using System;

namespace Fitness.BL.Model
{
    class Activity
    {
        /// <summary>
        /// Название активности
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество сжигаемых калорий на единицу времени
        /// </summary>
        public double CaloriesPerMinute { get; set; }

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
