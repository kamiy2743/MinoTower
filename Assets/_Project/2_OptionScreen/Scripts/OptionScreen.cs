using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.OptionScreen
{
    public class OptionScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;

        public ScreenType Type { get; private set; } = ScreenType.Option;

        public void Open()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public void CloseAsync()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }
    }
}
