using System;
namespace Fitness.BL.Model
{
    /// <summary>
    /// Класс Еда, включает в себя наименование и состав продуктов
    /// </summary>
    public class Food
    {
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

       
        private double CalloriesOneGramm { get { return Calories / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name)
        {
            // TODO: Проверка

        }

    }
}
