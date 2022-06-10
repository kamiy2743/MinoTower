using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    [System.Serializable]
    public class SwitchScreenHelper
    {
        [SerializeField] ScreenType _toSwitchType;
        [SerializeField] float _closeDuration = 0.5f;
        [SerializeField] float _openDuration = 0.5f;

        public void Switch()
        {
            ScreenSwitcher.Instance.Switch(_toSwitchType, _openDuration, _closeDuration);
        }
    }
}