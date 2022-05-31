using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.OptionScreen.States;

namespace MT.Screens.OptionScreen
{
    public class OptionScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;

        public ScreenType Type { get; private set; } = ScreenType.Option;

        public void Open()
        {
            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
