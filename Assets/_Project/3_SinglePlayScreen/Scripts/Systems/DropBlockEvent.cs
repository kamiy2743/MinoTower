using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MT.PlayScreen
{
    public class DropBlockEvent : MonoBehaviour, ICustomEvent, IStaticStart
    {
        private CustomEvent _customEvent = new CustomEvent();

        public void StaticStart()
        {
            UIEvent.Instance.AddListener(EventTriggerType.PointerUp, _customEvent.Invoke);
        }

        public void SetIsListened(bool value)
        {
            _customEvent.SetIsListened(value);
        }

        public void AddListener(UnityAction call)
        {
            _customEvent.AddListener(call);
        }
    }
}
