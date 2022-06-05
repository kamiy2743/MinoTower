using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Single
{
    public class RecordingMaxHeightState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private BlockConfig _config;

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

        public void EnterAsync()
        {
            RecordMaxHeight();
            _nextState.EnterAsync();
        }

        private void RecordMaxHeight()
        {
            var maxY = _blocksMaxYProvider.MaxY();
            var maxHeightValue = maxY - _foundation.GetTop();
            var heightMagnification = 1 / _config.BlockScale;
            _sessionData.MaxHeight = new MaxHeight(maxHeightValue * heightMagnification);
        }
    }
}

