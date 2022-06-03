using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MT.PlayScreen
{
    public class GameOverArea : MonoBehaviour, ICustomEvent
    {
        private CustomEvent _eventSubject = new CustomEvent();

        public void SetIsListened(bool value)
        {
            _eventSubject.SetIsListened(value);
        }

        public void AddListener(UnityAction call)
        {
            _eventSubject.AddListener(call);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<BlockTag>() != null)
            {
                _eventSubject.Invoke();
            }
        }
    }
}
