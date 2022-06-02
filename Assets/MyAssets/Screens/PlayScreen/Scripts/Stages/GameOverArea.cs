using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Events;
using UnityEngine.Events;

namespace MT.Screens.PlayScreen.Stages
{
    public class GameOverArea : MonoBehaviour, IEventListener
    {
        private EventSubject _eventSubject = new EventSubject();

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
            if (collider.transform.parent.GetComponent<MT.Blocks.BlockTag>() != null)
            {
                _eventSubject.Invoke();
            }
        }
    }
}
