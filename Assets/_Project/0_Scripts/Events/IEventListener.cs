using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MT
{
    public interface IEventListener
    {
        void SetIsListened(bool value);
        void AddListener(UnityAction call);
    }

    public interface IEventListener<T>
    {
        void SetIsListened(bool value);
        void AddListener(UnityAction<T> call);
    }
}
