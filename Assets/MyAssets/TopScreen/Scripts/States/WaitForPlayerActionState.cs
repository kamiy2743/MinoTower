using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using UnityEngine.UI;

namespace Mt.TopScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private ToPlayScreenState _toPlayScreenState;

        void Start()
        {
            gameObject.SetActive(false);
            _playButton.onClick.AddListener(() =>
            {
                Tonext(_toPlayScreenState);
            });
        }

        public void Enter()
        {
            gameObject.SetActive(true);
        }

        private void Tonext(IState nextState)
        {
            gameObject.SetActive(false);
            nextState.Enter();
        }
    }
}
