using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using MT.Screens.PlayScreen.Stages;
using MT.Screens.PlayScreen.Systems;

namespace MT.Screens.PlayScreen.States
{
    public class RecordingMaxHeightState : MonoBehaviour, IState
    {
        [SerializeField] private float _heightMagnification;
        [SerializeField] private PlayData _playData;
        [SerializeField] private BlocksMaxYProvider _blocksMaxYProvider;
        [SerializeField] private Foundation _foundation;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            var maxY = _blocksMaxYProvider.MaxY();
            var maxHeightValue = maxY - _foundation.GetTop();
            _playData.MaxHeight = new MaxHeight(maxHeightValue * _heightMagnification);
            _nextState.Enter();
        }
    }
}

