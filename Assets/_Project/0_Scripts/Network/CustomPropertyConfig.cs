using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    [CreateAssetMenu(fileName = "CustomPropertyConfig", menuName = "ScriptableObjects/CustomPropertyConfig")]
    public class CustomPropertyConfig : ScriptableObject
    {
        public string IsMasterClientTurnKey = "IsMasterClientTurn";
        public string TryConnectRoomNameKey = "TryConnectRoomName";
    }
}
