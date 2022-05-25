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
        [SerializeField] private InitializeState _initializeState;

        void Start()
        {
            _resultUI.ContinueButtonClick.AddListener(OnContinueButtonClick);
            _resultUI.ExitButtonClick.AddListener(OnExitButtonClick);
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            _resultUI.Show();
        }

        private void OnContinueButtonClick()
        {
            gameObject.SetActive(false);
            _resultUI.Hide(completed: () =>
            {
                _initializeState.Enter();
            });
        }

        private void OnExitButtonClick()
        {

        }
    }
}

