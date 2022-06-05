using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Multi
{
    public class ToNextTurnState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private PlayerTurnProvider _playerTurnProvider;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            _playerTurnProvider.NextTurn();
            ToNext();
        }

        private void ToNext()
        {
            _nextState.Enter();
        }
    }
}
