using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class FriendMatchRoomNameAccessor
    {
        private static string _roomName = "";

        public void Set(string roomName)
        {
            _roomName = roomName;
        }

        public string Get()
        {
            return _roomName;
        }

        public void SetEmpty()
        {
            Set("");
        }

        public bool IsEmpty()
        {
            return Get() == "";
        }
    }
}
