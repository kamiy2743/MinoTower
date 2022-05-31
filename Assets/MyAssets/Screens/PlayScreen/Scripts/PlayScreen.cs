using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.PlayScreen.States;
using MT.Screens.PlayScreen.Systems;

namespace MT.Screens.PlayScreen
{
    public class PlayScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;
        [SerializeField] private ScreenScroller _screenScroller;

        public ScreenType Type { get; private set; } = ScreenType.Play;

        public void Open()
        {
            if (gameObject.activeSelf) return;
            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public void Close()
        {
            if (!gameObject.activeSelf) return;
            _screenScroller.Initialize();
            gameObject.SetActive(false);
        }
    }
}
