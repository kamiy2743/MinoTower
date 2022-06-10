using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.OptionScreen
{
    public class PreInitializeState : MonoBehaviour, IPreInitializeState
    {
        [Header("初期化対象")]
        [SerializeField] private AudioSettingApplier _audioSettingApplier;

        public void Enter()
        {
            _audioSettingApplier.Initialize();
        }
    }
}
