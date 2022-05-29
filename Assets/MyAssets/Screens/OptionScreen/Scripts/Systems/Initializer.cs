using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Screens.OptionScreen.Systems
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private AudioSettingApplier _audioSettingApplier;

        public void Execute()
        {
            _audioSettingApplier.Initialize();
        }
    }
}
