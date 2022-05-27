using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;

namespace MT.Screens.PlayScreen.States
{
    public class BlockFallState : MonoBehaviour, IState
    {
        [SerializeField] private ActiveBlockProvider _activeBlockProvider;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            _activeBlockProvider.Get().StartFall();
            ToNext();
        }

        public void ToNext()
        {
            _nextState.Enter();
        }
    }
}

