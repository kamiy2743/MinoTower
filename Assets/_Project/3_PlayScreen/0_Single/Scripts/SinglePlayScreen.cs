using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Single
{
    public class SinglePlayScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;

        [Header("初期化対象")]
        [SerializeField] private ScreenScroller _screenScroller;

        public ScreenType Type { get; private set; } = ScreenType.SinglePlay;

        public void Open()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public async void Close()
        {
            if (!gameObject.activeSelf) return;

            await _screenScroller.Initialize();
            gameObject.SetActive(false);
        }
    }
}
