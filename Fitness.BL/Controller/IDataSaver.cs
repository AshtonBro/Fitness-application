using System;

namespace Fitness.BL.Controller
{
    public interface IDataSaver<T> where T: class
    {
        void Save(T item);

        T Load();
    }
}
