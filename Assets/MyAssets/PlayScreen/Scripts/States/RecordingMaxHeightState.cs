using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;

namespace MT.PlayScreen.States
{
    public class RecordingMaxHeightState : MonoBehaviour, IState
    {
        [SerializeField] private PlayData _playData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            _playData.MaxHeight = _blockStore.CalcMaxHeight();
            ToNext();
        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }
    }
}

