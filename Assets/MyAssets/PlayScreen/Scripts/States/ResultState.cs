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
        [SerializeField] private ToTopScreenState _toTopScreenState;

        void Start()
        {
            _resultUI.ContinueButtonClick.AddListener(OnContinueButtonClick);
            _resultUI.ExitButtonClick.AddListener(OnExitButtonClick);
        }

        public void Enter()
        {
            _resultUI.Show();
        }

        private void ToNext(IState nextState)
        {
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
            ToNext(_toTopScreenState);
        }
    }
}

