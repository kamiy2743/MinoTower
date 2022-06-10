using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class SwitchScreenState : MonoBehaviour, IState
    {
        [SerializeField] private ScreenType _toSwitchType;

        public async void Enter()
        {
            await ScreenSwitcher.Instance.SwitchAsync(_toSwitchType, 0.5f, 0.5f);
        }
    }
}
