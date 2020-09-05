using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Идентификаторы для EntityFramework
        /// </summary>
        public int Id { get; set; }

        #region Properties for user
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///Пол 
        /// </summary>
        public Gender Gender { get; set;  }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
        // DateTime nowDate = DateTime.Today;
        // int Age = nowDate.Year - birthDate.Year;
        // if(birthDate > nowDate.AddYears(-age)) age--;
        #endregion

        /// <summary>
        /// Конструктор для создания нового пользователя
        /// </summary>
        /// <param name="_name">Имя</param>
        /// <param name="_gender">Пол</param>
        /// <param name="_dateofbirth">Дата рождения</param>
        /// <param name="_weight">Вес</param>
        /// <param name="_height">Рост</param>
        public User(string name, Gender gender, DateTime dateofbirth, double weight, double height)
        {
            #region Checking input parameters
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of user can not be null or with white space");
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can not be null", nameof(gender));
            }

            if(dateofbirth < DateTime.Parse("01.01.1950") || dateofbirth >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth", nameof(dateofbirth));
            }

            if(weight <= 0)
            {
                throw new ArgumentException("The weight can not be smaller or is equal than 0", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("The height can not be smaller or is equal than 0", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            DateOfBirth = dateofbirth;
            Weight = weight;
            Height = height;
        }

        /// <summary>
        /// Проверка name на пробелы и null
        /// </summary>
        /// <param name="name">Имя</param>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of user can not be null or with white space");
            }

            Name = name;
        }

        /// <summary>
        /// Переназначенный ToString
        /// </summary>
        /// <returns>Имя и Пол.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
