using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class TryConnectRoomNameProvider : MonoBehaviour
    {
        [SerializeField] private CustomPropertyConfig _config;
        private static string _roomName = "";

        public void SetRoomName(string value)
        {
            _roomName = value;
        }

        public string GetRoomName()
        {
            return _roomName;
        }

        public void SetEmpty()
        {
            SetRoomName("");
        }

        public bool IsEmpty()
        {
            return GetRoomName() == "";
        }
    }
}
