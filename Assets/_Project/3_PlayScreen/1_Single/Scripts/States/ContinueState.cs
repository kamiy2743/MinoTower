using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Single
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private SwitchScreenHelper _toSinglePlayScreen;

        public void Enter()
        {
            _toSinglePlayScreen.Switch();
        }
    }
}
