using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.TopScreen.States;

namespace MT.TopScreen
{
    public class TopScreen : MonoBehaviour
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
