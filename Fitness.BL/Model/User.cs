using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    class User
    {
        #region Properties for user
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        ///Пол 
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime DateOfBirth { get;}
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Конструктор для создания нового пользователя
        /// </summary>
        /// <param name="_name">Имя</param>
        /// <param name="_gender">Пол</param>
        /// <param name="_dateofbirth">Дата рождения</param>
        /// <param name="_weight">Вес</param>
        /// <param name="_height">Рост</param>
        public User(string _name, Gender _gender, DateTime _dateofbirth, double _weight, double _height)
        {
            #region Checking input parameters
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentNullException("Name of user can not be null or with white space");
            }

            if (Gender == null)
            {
                throw new ArgumentNullException("Gender can not be null", nameof(_gender));
            }

            if(_dateofbirth < DateTime.Parse("01.01.1950") || _dateofbirth >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth", nameof(_dateofbirth));
            }

            if(_weight <= 0)
            {
                throw new ArgumentException("The weight can not be smaller or is equal than 0", nameof(_weight));
            }

            if(_height <= 0)
            {
                throw new ArgumentException("The height can not be smaller or is equal than 0", nameof(_height));
            }
            #endregion

            Name = _name;
            Gender = _gender;
            DateOfBirth = _dateofbirth;
            Weight = _weight;
            Height = _height;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Gender: {Gender}";
        }
    }
}
