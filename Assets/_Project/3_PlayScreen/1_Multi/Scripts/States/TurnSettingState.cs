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
            _blockSynchronizer.SetIsSynchronize(true);

            if (_playerTurnProvider.IsMyTurn())
            {
                _blockSynchronizer.photonView.RequestOwnership();
                await _rotateButton.ShowAsync(_fadeDuraiton);
            }
            else
            {
                await _rotateButton.HideAsync(_fadeDuraiton);
            }

            ToNext();
        }

        private void ToNext()
        {
            _nextState.Enter();
        }
    }
}
