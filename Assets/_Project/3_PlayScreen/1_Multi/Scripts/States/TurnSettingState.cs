using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Multi
{
    public class TurnSettingState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private PlayerTurnProvider _playerTurnProvider;
        [SerializeField] private BlockSynchronizer _blockSynchronizer;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            if (_playerTurnProvider.IsMyTurn())
            {

            }
            else
            {

            }

            // ToNext();
        }

        private void ToNext()
        {
            _nextState.Enter();
        }
    }
}
