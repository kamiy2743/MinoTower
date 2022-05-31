using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.TopScreen.States;
using MT.Screens;

namespace MT.Screens.TopScreen
{
    public class TopScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;

        public ScreenType Type { get; private set; } = ScreenType.Top;

        public void Open()
        {
            // TODO 開いてるときは流す
            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public void Close()
        {
            // TODO 閉じてるときは流す
            gameObject.SetActive(false);
        }
    }
}
