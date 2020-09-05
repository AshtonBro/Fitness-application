using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        /// <summary>
        /// Идентификация пользователя
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список упражнений
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// Справочник активностей
        /// </summary>
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User can not be is null", nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        /// <summary>
        /// Добавление физической активности
        /// </summary>
        /// <param name="activityName">Название активности</param>
        /// <param name="start">Время начала</param>
        /// <param name="finish">Время окончания</param>
        public void AddExercise(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.SingleOrDefault(f => f.Name == activity.Name);
            if(act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, finish, act, user);
                Exercises.Add(exercise);
            }

            Save();
        }

        /// <summary>
        /// Получаем весь список упражнений
        /// </summary>
        /// <returns>Список упражнений</returns>
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Сохраняем список всех упражнений
        /// </summary>
        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
