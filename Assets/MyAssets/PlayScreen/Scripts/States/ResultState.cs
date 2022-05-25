using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ResultState : MonoBehaviour, IState
    {
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private ContinueState _continueState;
        [SerializeField] private ExitState _exitState;

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

        private void ToNext(IState nextState)
        {
            gameObject.SetActive(false);
            _resultUI.Hide(completed: () =>
            {
                nextState.Enter();
            });
        }

        private void OnContinueButtonClick()
        {
            ToNext(_continueState);
        }

        private void OnExitButtonClick()
        {
            ToNext(_exitState);
        }
    }
}

