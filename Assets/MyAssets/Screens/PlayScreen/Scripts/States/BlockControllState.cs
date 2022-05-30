using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.Systems;
using MT.Blocks;
using MT.Util.UI;

namespace MT.Screens.PlayScreen.States
{
    public class BlockControllState : MonoBehaviour, IState
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private CustomButton _rotateButton;
        [SerializeField] private ActiveBlockProvider _ativeBlockProvider;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;
        private Block _activeBlock => _ativeBlockProvider.Get();

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        void Start()
        {
            _rotateButton.AddListener(() =>
            {
                _activeBlock.Rotate();
            });

            _playerInput.MoveBlockAddListener(() =>
            {
                var pos = _activeBlock.transform.position;
                pos.x = _playerInput.PointerPosition().x;
                _activeBlock.transform.position = pos;
            });

            _playerInput.DropBlockAddListener(() =>
            {
                ToNext();
            });
        }

        public void Enter()
        {
            _rotateButton.SetInteractable(true);
        }

        public void ToNext()
        {
            _rotateButton.SetInteractable(false);
            _nextState.Enter();
        }
    }
}
