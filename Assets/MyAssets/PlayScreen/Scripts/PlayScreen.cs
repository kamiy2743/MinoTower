using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.PlayScreen.States;
using MT.Screens;

namespace MT.PlayScreen
{
    public class PlayScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EnterState _enterState;

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
            gameObject.SetActive(false);
        }
    }
}
