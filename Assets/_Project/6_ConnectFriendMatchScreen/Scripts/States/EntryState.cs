using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.ConnectFriendMatchScreen
{
    public class EntryState : MonoBehaviour, IState
    {
        [SerializeField] private TryConnectRoomNameProvider _tryConnectRoomNameProvider;
        [SerializeField] private RoomSettingState _roomSettingState;
        [SerializeField] private ConnectMatchState _connectMatchState;

        public void Enter()
        {
            if (_tryConnectRoomNameProvider.IsEmpty())
            {
                _roomSettingState.Enter();
            }
            else
            {
                _connectMatchState.Enter();
            }
        }
    }
}
