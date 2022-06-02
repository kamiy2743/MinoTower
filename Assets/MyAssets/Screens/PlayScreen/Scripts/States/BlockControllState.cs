using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.Systems;
using MT.Blocks;
using MT.Util.UI;

namespace MT.Screens.PlayScreen.States
{
    public class BlockControllState : MonoBehaviour, IState, IStaticAwake, IStaticStart
    {
        [SerializeField] private MoveBlockEvent _moveBlockEvent;
        [SerializeField] private DropBlockEvent _dropBlockEvent;
        [SerializeField] private PointerPositionProvider _pointerPositionProvider;
        [SerializeField] private CustomButton _rotateButton;
        [SerializeField] private ActiveBlockProvider _ativeBlockProvider;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;
        private Block _activeBlock => _ativeBlockProvider.Get();

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void StaticStart()
        {
            _rotateButton.AddListener(async () =>
            {
                _rotateButton.SetIsListened(false);
                await _activeBlock.Rotate();
                _rotateButton.SetIsListened(true);
            });

            _moveBlockEvent.AddListener(() =>
            {
                var pos = _activeBlock.transform.position;
                pos.x = _pointerPositionProvider.Get().x;
                _activeBlock.transform.position = pos;
            });

            _dropBlockEvent.AddListener(() =>
            {
                ToNext();
            });
        }

        public void Enter()
        {
            _moveBlockEvent.SetInteractable(true);
            _dropBlockEvent.SetInteractable(true);
            _rotateButton.SetIsListened(true);
        }

        public void ToNext()
        {
            _moveBlockEvent.SetInteractable(false);
            _dropBlockEvent.SetInteractable(false);
            _rotateButton.SetIsListened(false);
            _nextState.Enter();
        }
    }
}
