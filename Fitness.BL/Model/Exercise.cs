using System;

namespace Fitness.BL.Model
{
    public class Exercise
    {
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
    }
}
