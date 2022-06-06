using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.ConnectFriendMatchScreen
{
    public class ConnectFriendMatchScreen : MonoBehaviour, IScreen
    {
        // [SerializeField] private EntryState _entryState;

        public ScreenType Type { get; private set; } = ScreenType.ConnectFriendMatch;

        public void Open()
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            // _entryState.Enter();
        }

        public void CloseAsync()
        {
            if (!gameObject.activeSelf) return;

            gameObject.SetActive(false);
        }
    }
}
