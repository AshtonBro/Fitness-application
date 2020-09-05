using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Приём пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Идентификаторы для EntityFramework
        /// </summary>
        public int Id { get; set; }
        public DateTime  MomentOfEating { get; set; }

        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can not be null", nameof(user));
            MomentOfEating = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Возможность добавлять продукт питания
        /// </summary>
        /// <param name="food">Наименование продукта</param>
        /// <param name="calorie">Калории</param>
        public void Add(Food food, double calorie)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, calorie);
            }
            else
            {
                Foods[product] += calorie;
            }
        }
    }
}
