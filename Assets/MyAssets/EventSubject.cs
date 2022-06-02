using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;

namespace MT.Events
{
    public class EventSubject : IEventListener
    {
        private Subject<string> _subject = new Subject<string>();
        private bool _isListened = false;

        public void SetIsListened(bool value)
        {
            _isListened = value;
        }

        public void AddListener(UnityAction call)
        {
            _subject.Subscribe(_ => call.Invoke());
        }

        public void Invoke()
        {
            _subject.OnNext("");
        }
    }
}
