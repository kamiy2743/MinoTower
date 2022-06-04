using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MT.PlayScreen
{
    public class GameOverArea : MonoBehaviour, ICustomEvent
    {
        private CustomEvent _customEvent = new CustomEvent();

        public void SetIsListened(bool value)
        {
            _customEvent.SetIsListened(value);
        }

        public void AddListener(UnityAction call)
        {
            _customEvent.AddListener(call);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<BlockTag>() != null)
            {
                _customEvent.Invoke();
            }
        }
    }
}
