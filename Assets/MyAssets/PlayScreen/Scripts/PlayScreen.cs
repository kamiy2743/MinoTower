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

        public bool isOpened { get; private set; }
        public bool isActive => gameObject.activeSelf;

        public void Open()
        {
            isOpened = true;
            gameObject.SetActive(true);
            _enterState.Enter();
        }

        public void Close()
        {
            isOpened = false;
            gameObject.SetActive(false);
        }
    }
}
