using System;
namespace Fitness.BL.Model
{
    /// <summary>
    /// Класс Еда, включает в себя наименование и состав продуктов
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Идентификаторы для EntityFramework
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100гр продукта
        /// </summary>
        public double Calories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: Проверка

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        /// <summary>
        /// Переопределили toString для продукта питания
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Продукт: {Name}, Калорийность: {Calories}.";
        }

    }
}
