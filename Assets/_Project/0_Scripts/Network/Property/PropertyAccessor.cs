using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UniRx;
using Cysharp.Threading.Tasks;

namespace MT.Network
{
    public class PropertyAccessor : MonoBehaviourPunCallbacks, IStaticAwake
    {
        public static PropertyAccessor Instance => _instance;
        private static PropertyAccessor _instance;

        private string _separator = ":separate:";
        private Dictionary<string, bool> _dic = new Dictionary<string, bool>();

        public void StaticAwake()
        {
            _instance = this;
        }

        public async UniTask SetAsync<T>(PropertyType type, PropertyKey key, T value)
        {
            var time = System.DateTime.Now.Ticks;
            var id = time + key.ToString() + _separator + value;

            var cp = PhotonNetwork.LocalPlayer.CustomProperties;
            cp[key.ToString()] = id;

            if (type == PropertyType.Room)
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(cp);
            }
            else
            {
                PhotonNetwork.LocalPlayer.SetCustomProperties(cp);
            }

            _dic[id] = false;
            await UniTask.WaitUntil(() => _dic[id]);
            _dic.Remove(id);
        }

        public T Get<T>(PropertyType type, PropertyKey key)
        {
            object id;
            if (type == PropertyType.Room)
            {
                id = PhotonNetwork.CurrentRoom.CustomProperties[key.ToString()];
            }
            else
            {
                id = PhotonNetwork.LocalPlayer.CustomProperties[key.ToString()];
            }

            string value = id.ToString().Split(_separator)[1];
            return (T)System.Convert.ChangeType((object)value, typeof(T));
        }

        // TODO えぐい
        public override void OnPlayerPropertiesUpdate(Player target, ExitGames.Client.Photon.Hashtable propertiesThatChanged)
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
