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
        public bool IsListened { get; private set; } = false;

        public void SetIsListened(bool value)
        {
            IsListened = value;
        }

        public void AddListener(UnityAction call)
        {
            _subject
                .Where(_ => IsListened)
                .Subscribe(_ => call.Invoke());
        }

        public void Invoke()
        {
            _subject.OnNext("");
        }
    }

    public class EventSubject<T> : IEventListener<T>
    {
        private Subject<T> _subject = new Subject<T>();
        public bool IsListened { get; private set; } = false;

        public void SetIsListened(bool value)
        {
            IsListened = value;
        }

        public void AddListener(UnityAction<T> call)
        {
            _subject
                .Where(_ => IsListened)
                .Subscribe(arg => call.Invoke(arg));
        }

        public void Invoke(T arg)
        {
            _subject.OnNext(arg);
        }
    }
}
