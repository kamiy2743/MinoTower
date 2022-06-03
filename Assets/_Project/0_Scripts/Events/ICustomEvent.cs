using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MT
{
    public interface ICustomEvent
    {
        void SetIsListened(bool value);
        void AddListener(UnityAction call);
    }

    public interface ICustomEvent<T>
    {
        void SetIsListened(bool value);
        void AddListener(UnityAction<T> call);
    }
}
