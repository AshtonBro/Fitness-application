using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название пола
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="_name">Имя пола</param>
        public Gender(string _name)
        {
            if(string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentNullException("Name is not can be null or with white space");
            }
            Name = _name;
        }
        /// <summary>
        /// Переназначенный ToString 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
