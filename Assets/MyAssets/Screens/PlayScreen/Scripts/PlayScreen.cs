using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.PlayScreen.States;
using MT.Screens.PlayScreen.Systems;

namespace MT.Screens.PlayScreen
{
    public class PlayScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EnterState _enterState;
        [SerializeField] private ScreenScroller _screenScroller;

        public ScreenType ScreenType { get; private set; } = ScreenType.Play;
        public bool IsOpened { get; private set; }
        public bool IsActive => gameObject.activeSelf;

        public void Open()
        {
            IsOpened = true;
            gameObject.SetActive(true);
            _enterState.Enter();
        }

        public void Close()
        {
            IsOpened = false;
            _screenScroller.Initialize();
            gameObject.SetActive(false);
        }
    }
}
