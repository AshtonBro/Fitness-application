using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователи приложения
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Флаг, а новый пользователь ?
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="userName">Пользователь</param>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("The user name can not be is empty", nameof(userName));
            }

            Users = GetUsersDate();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        private List<User> GetUsersDate()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime dateOfBirth, double weight = 1, double height = 1)
        {
            // Проверка 
           CurrentUser.Gender
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        private void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs , Users);
            }
        }
    }
}
