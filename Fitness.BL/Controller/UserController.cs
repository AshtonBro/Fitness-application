﻿using Fitness.BL.Model;
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
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Константа имя файла пользователей
        /// </summary>
        private const string USERS_FILE_NAME = "users.dat";

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
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();

        }

        /// <summary>
        /// Если имя уже есть, то добавляем новую информацию по пользователю
        /// </summary>
        /// <param name="genderName">Пол</param>
        /// <param name="dateOfBirth">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public void SetNewUserData(string genderName, DateTime dateOfBirth, double weight = 1, double height = 1)
        {
            // Проверка 
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.DateOfBirth = dateOfBirth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        private void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
    }
}
