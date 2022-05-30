using UnityEngine;

namespace MT.Application.SaveData
{
    public interface ILoadData
    {
        T Load<T>(string key, T defaultvalue);
    }
}