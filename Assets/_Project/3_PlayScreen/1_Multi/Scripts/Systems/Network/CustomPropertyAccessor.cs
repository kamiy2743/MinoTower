using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UniRx;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Multi
{
    public class CustomPropertyAccessor : MonoBehaviourPunCallbacks, IStaticAwake
    {
        public static CustomPropertyAccessor Instance => _instance;
        private static CustomPropertyAccessor _instance;

        private string _separator = ":separate:";
        private Dictionary<string, bool> _dic = new Dictionary<string, bool>();

        public void StaticAwake()
        {
            _instance = this;
        }

        public async UniTask SetAsync<T>(string key, T value)
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.LogError("not in room");
            }

            var time = System.DateTime.Now.Ticks;
            var id = time + key + _separator + value;

            var cp = PhotonNetwork.CurrentRoom.CustomProperties;
            cp[key] = id;
            PhotonNetwork.CurrentRoom.SetCustomProperties(cp);

            _dic[id] = false;
            await UniTask.WaitUntil(() => _dic[id]);
            _dic.Remove(id);
        }

        public T Get<T>(string key)
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.LogError("not in room");
            }

            string value = PhotonNetwork.CurrentRoom.CustomProperties[key].ToString().Split(_separator)[1];
            return (T)System.Convert.ChangeType((object)value, typeof(T));
        }

        // TODO えぐい
        public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
        {
            foreach (var value in propertiesThatChanged.Values)
            {
                foreach (var key in _dic.Keys)
                {
                    if (key == value.ToString())
                    {
                        _dic[key] = true;
                        break;
                    }
                }
            }
        }
    }
}
