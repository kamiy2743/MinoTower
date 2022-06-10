using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private SwitchScreenHelper _toConnectFriendMatchScreen;

        public void Enter()
        {
            _toConnectFriendMatchScreen.Switch();
        }
    }
}
