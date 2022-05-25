using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.PlayScreen;

namespace MT.PlayScreen.States
{
    public class ResultState : MonoBehaviour, IState
    {
        [SerializeField] private ResultUI _resultUI;

        void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            _resultUI.Show();
        }
    }
}

