using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.OptionScreen.States;

namespace MT.Screens.OptionScreen
{
    public class OptionScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EnterState _enterState;

        public ScreenType ScreenType { get; private set; } = ScreenType.Option;
        public bool IsOpened { get; private set; }
        public bool IsActive => gameObject.activeSelf;

        public void Open()
        {
            IsOpened = true;
            gameObject.SetActive(true);
            // _enterState.Enter();
        }

        public void Close()
        {
            IsOpened = false;
            gameObject.SetActive(false);
        }
    }
}
