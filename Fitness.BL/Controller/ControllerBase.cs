using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Базовый класс контролера включающий в себя часто использующие методы
    /// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// Метод сохранения объекта (users, foods)
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="item">Тип объекта</param>
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Метод загрузки объекта (users, foods)
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
