using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class TopScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;

        public ScreenType Type { get; private set; } = ScreenType.Top;

        public void Open()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            _entryState.EnterAsync();
        }

        public void CloseAsync()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }
    }
}
