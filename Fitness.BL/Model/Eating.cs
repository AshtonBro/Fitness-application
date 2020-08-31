using System;
using System.Collections.Generic;

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
            MomentOfEating = DateTime.Now;
            Foods = new Dictionary<Food, double>();
        }
    }
}
