using Fitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="_user">Пользователь</param>
        public UserController(User _user)
        {
            User = _user ?? throw new ArgumentNullException("User can not be null", nameof(_user));
        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs ,User);
            }
        }

        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
    }
}
