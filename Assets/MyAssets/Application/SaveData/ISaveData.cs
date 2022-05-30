using UnityEngine;

namespace MT.Application.SaveData
{
    public interface ISaveData
    {
        void Save<T>(string key, T value);
    }
}