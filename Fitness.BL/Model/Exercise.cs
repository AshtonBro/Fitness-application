using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Класс упражнений, включает в себя: дату, вид активности, исполнителя упражнения
    /// </summary>
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Идентификаторы для EntityFramework
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата начала выполнения упражнения
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Дата окончания выполнения упражнения
        /// </summary>
        public DateTime Finish { get; }

        /// <summary>
        /// Выполняемая активность (упражнение)
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Кто делал упражнения
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Конструктор упражнения
        /// </summary>
        /// <param name="start">Время начала</param>
        /// <param name="finish">Время окончания</param>
        /// <param name="activity">Вид упражнения</param>
        /// <param name="user">Исполнитель упражнения</param>
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // Проверка входных параметров
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

        public override string ToString()
        {
            return $"Упражнение: {Activity}, Пользователь: {User}";
        }
    }
}
