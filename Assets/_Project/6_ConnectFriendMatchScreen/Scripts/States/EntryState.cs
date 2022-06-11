using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.ConnectFriendMatchScreen
{
    public class EntryState : MonoBehaviour, IState
    {
        [SerializeField] private RoomSettingState _roomSettingState;
        [SerializeField] private ConnectMatchState _connectMatchState;

        private FriendMatchRoomNameAccessor _friendMatchRoomNameAccessor = new FriendMatchRoomNameAccessor();

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
