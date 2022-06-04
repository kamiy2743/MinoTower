using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class RecordingMaxHeightState : MonoBehaviour, IState, IStaticAwake
    {
        // TODO config
        [SerializeField] private float _heightMagnification;

        [Space(20)]
        [SerializeField] private SessionData _sessionData;
        [SerializeField] private BlocksMaxYProvider _blocksMaxYProvider;
        [SerializeField] private Foundation _foundation;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            RecordMaxHeight();
            _nextState.Enter();
        }

        private void RecordMaxHeight()
        {
            var maxY = _blocksMaxYProvider.MaxY();
            var maxHeightValue = maxY - _foundation.GetTop();
            _sessionData.MaxHeight = new MaxHeight(maxHeightValue * _heightMagnification);
        }
    }
}

