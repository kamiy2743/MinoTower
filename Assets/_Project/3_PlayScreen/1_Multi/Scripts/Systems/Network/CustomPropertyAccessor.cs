using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class CustomPropertyAccessor : MonoBehaviour, IStaticAwake
    {
        public static CustomPropertyAccessor Instance => _instance;
        private static CustomPropertyAccessor _instance;

        public void StaticAwake()
        {
            _instance = this;
        }

        public void Set<T>(string key, T value)
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.LogError("not in room");
            }

            var cp = PhotonNetwork.CurrentRoom.CustomProperties;
            cp[key] = value;
            PhotonNetwork.CurrentRoom.SetCustomProperties(cp);
        }

        public T Get<T>(string key)
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.LogError("not in room");
            }

            var value = PhotonNetwork.CurrentRoom.CustomProperties[key];
            return (T)value;
        }
    }
}
