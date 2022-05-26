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
        [SerializeField] private Foundation _foundation;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            var maxY = _blockStore.GetMaxY();
            var maxHeightValue = maxY - _foundation.GetTop();
            Debug.Log(maxHeightValue);
            _playData.MaxHeight = new MaxHeight(maxHeightValue);
            _nextState.Enter();
        }
    }
}

