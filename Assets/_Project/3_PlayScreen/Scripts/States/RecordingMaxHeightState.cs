using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class RecordingMaxHeightState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _heightMagnification;
        [SerializeField] private SessionData _sessionData;
        [SerializeField] private BlocksMaxYProvider _blocksMaxYProvider;
        [SerializeField] private Foundation _foundation;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            var maxY = _blocksMaxYProvider.MaxY();
            var maxHeightValue = maxY - _foundation.GetTop();
            _sessionData.MaxHeight = new MaxHeight(maxHeightValue * _heightMagnification);
            _nextState.Enter();
        }
    }
}

