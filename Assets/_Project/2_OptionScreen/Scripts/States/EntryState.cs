using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.OptionScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private AudioSettingApplier _audioSettingApplier;

        private IState _nextState;

        public void StaticAwake()
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
            _audioSettingApplier.Initialize();
        }
    }
}
