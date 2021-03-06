using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Multi
{
    public class TurnSettingState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private BlockSynchronizer _blockSynchronizer;

        [Space(20)]
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private PlayerTurnAccessor _playerTurnAccessor = new PlayerTurnAccessor();
        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            _blockSynchronizer.SetIsSynchronize(true);

            if (_playerTurnAccessor.IsMyTurn())
            {
                _blockSynchronizer.photonView.RequestOwnership();
                await _rotateButton.ShowAsync(_fadeDuration);
            }
            else
            {
                await _rotateButton.HideAsync(_fadeDuration);
            }

            ToNext();
        }

        private void ToNext()
        {
            _nextState.Enter();
        }
    }
}
