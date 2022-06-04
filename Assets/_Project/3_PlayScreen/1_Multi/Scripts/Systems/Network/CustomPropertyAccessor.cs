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
            var hashtable = new ExitGames.Client.Photon.Hashtable();
            hashtable[key] = value;
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
        }

        public T Get<T>(string key)
        {
            var value = PhotonNetwork.CurrentRoom.CustomProperties[key];
            return (T)value;
        }
    }
}
