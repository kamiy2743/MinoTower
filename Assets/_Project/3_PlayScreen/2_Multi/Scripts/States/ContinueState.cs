using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private SwitchScreenHelper _toConnectRandomMatchScreen;
        [SerializeField] private SwitchScreenHelper _toConnectFriendMatchScreen;

        public void Enter()
        {
            var currentMatchtype = new CurrentMatchTypeAccessor().Get();

            switch (currentMatchtype)
            {
                case MatchType.Random:
                    _toConnectRandomMatchScreen.Switch();
                    break;
                case MatchType.Friend:
                    _toConnectFriendMatchScreen.Switch();
                    break;
                default:
                    break;
            }
        }
    }
}
