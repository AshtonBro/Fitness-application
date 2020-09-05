using System.Collections.Generic;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Базовый класс контролера включающий в себя часто использующие методы
    /// </summary>
    public abstract class ControllerBase
    {
        protected readonly IDataSaver manager = new SerializeDataServer(); // new DataBaseDataSaver(); // new SerializeDataServer();
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}