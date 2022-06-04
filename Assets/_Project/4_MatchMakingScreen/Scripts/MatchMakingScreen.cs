using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.MatchMakingScreen
{
    public class MatchMakingScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private EntryState _entryState;

        public ScreenType Type { get; private set; } = ScreenType.MatchMaking;

        public void Open()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            _entryState.Enter();
        }

        public void Close()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }
    }
}
