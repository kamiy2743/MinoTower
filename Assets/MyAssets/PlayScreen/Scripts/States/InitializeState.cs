using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;

namespace MT.PlayScreen.States
{
    public class InitializeState : MonoBehaviour, IState
    {
        [SerializeField] private PlayData _playData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            Initialize();
            _nextState.Enter();
        }

        private void Initialize()
        {
            _playData.Initialize();
            _blockStore.Initialize();
        }
    }
}

