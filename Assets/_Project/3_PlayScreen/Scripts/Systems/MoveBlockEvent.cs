using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MT.PlayScreen
{
    public class MoveBlockEvent : MonoBehaviour, IEventListener, IStaticStart
    {
        private EventSubject _eventSubject = new EventSubject();

        public void StaticStart()
        {
            UIEvent.Instance.AddListener(EventTriggerType.PointerDown, _eventSubject.Invoke);
            UIEvent.Instance.AddListener(EventTriggerType.Drag, _eventSubject.Invoke);
        }

        public void SetIsListened(bool value)
        {
            _eventSubject.SetIsListened(value);
        }

        public void AddListener(UnityAction call)
        {
            _eventSubject.AddListener(call);
        }
    }
}