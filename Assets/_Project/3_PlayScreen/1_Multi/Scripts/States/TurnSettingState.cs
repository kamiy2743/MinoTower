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
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private float _fadeDuraiton;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            if (_playerTurnProvider.IsMyTurn())
            {
                await _rotateButton.Show(_fadeDuraiton);
            }
            else
            {
                await _rotateButton.Hide(_fadeDuraiton);
            }

            ToNext();
        }

        private void ToNext()
        {
            _nextState.Enter();
        }
    }
}
