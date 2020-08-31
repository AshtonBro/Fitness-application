using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Приём пищи
    /// </summary>
    public class Eating
    {
        public DateTime  MomentOfEating { get; }

        public Dictionary<Food, double> Foods { get; }

        public User User { get; }

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
