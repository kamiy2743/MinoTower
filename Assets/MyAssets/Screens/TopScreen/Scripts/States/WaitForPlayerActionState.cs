using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using UnityEngine.UI;

namespace MT.Screens.TopScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private ToPlayScreenState _toPlayScreenState;

        void Start()
        {
            _playButton.onClick.AddListener(() =>
            {
                Tonext(_toPlayScreenState);
            });
        }

        public void Enter()
        {
        }

        private void Tonext(IState nextState)
        {
            nextState.Enter();
        }
    }
}
