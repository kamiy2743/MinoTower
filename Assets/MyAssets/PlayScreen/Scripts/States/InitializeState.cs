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

        void Start()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
            Enter();
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            Initialize();
            ToNext();
        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }

        private void Initialize()
        {
            _playData.Initialize();
            _blockStore.Initialize();
        }
    }
}

