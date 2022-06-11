using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.ConnectFriendMatchScreen
{
    public class EntryState : MonoBehaviour, IState
    {
        [SerializeField] private FriendMatchRoomNameAccessor _friendMatchRoomNameAccessor;
        [SerializeField] private RoomSettingState _roomSettingState;
        [SerializeField] private ConnectMatchState _connectMatchState;

        public void Enter()
        {
            if (_friendMatchRoomNameAccessor.IsEmpty())
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
