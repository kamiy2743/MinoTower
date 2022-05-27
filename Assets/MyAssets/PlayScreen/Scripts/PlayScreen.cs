using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.PlayScreen.States;

namespace MT.PlayScreen
{
    public class PlayScreen : MonoBehaviour
    {
        [SerializeField] private EnterState _enterState;

        public void Open()
        {
            gameObject.SetActive(true);
            _enterState.Enter();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
