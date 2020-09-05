using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Базовый класс контролера включающий в себя часто использующие методы
    /// </summary>
    public abstract class ControllerBase<T> where T : class
    {
        protected IDataSaver<T> manger = new SerializeDataServer<T>();
        protected void Save(T item)
        {
            manger.Save(item);
        }

        protected List<T> Load()
        {
            return manger.Load();
        }
    }
}



///// <summary>
///// Метод сохранения объекта (users, foods)
///// </summary>
///// <param name="fileName">Имя файла</param>
///// <param name="item">Тип объекта</param>
//protected void Save(string fileName, object item)
//{

//}

///// <summary>
///// Метод загрузки объекта (users, foods)
///// </summary>
///// <typeparam name="T">Тип объекта</typeparam>
///// <param name="fileName">Имя файла</param>
///// <returns></returns>
//protected T Load<T>(string fileName) where T : class
//{
//   return saver.Load<T>(fileName);
//}