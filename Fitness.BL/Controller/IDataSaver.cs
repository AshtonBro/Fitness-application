using System;

namespace Fitness.BL.Controller
{
    public interface IDataSaver<T>
    {
        void Save(string fileName, object item);

        T Load<T>(string fileName) where T : class;
    }
}
