using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UniRx;
using Cysharp.Threading.Tasks;

namespace MT
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
            var keyStr = key.ToString();

            var time = System.DateTime.Now.Ticks;
            var id = time + keyStr + _separator + value;

            var cp = GetCustomProperties(type);
            cp[keyStr] = id;
            SetCustomProperties(type, cp);

            _dic[id] = false;
            await UniTask.WaitUntil(() => _dic[id]);
            _dic.Remove(id);
        }

        public T Get<T>(PropertyType type, PropertyKey key)
        {
            var keyStr = key.ToString();

            object id = GetCustomProperties(type)[keyStr];

            string value = id.ToString().Split(_separator)[1];

            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), value);
            }

            return (T)System.Convert.ChangeType((object)value, typeof(T));
        }

        public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
        {
            Check(propertiesThatChanged);
        }

        public override void OnPlayerPropertiesUpdate(Player _, ExitGames.Client.Photon.Hashtable propertiesThatChanged)
        {
            Check(propertiesThatChanged);
        }

        // TODO えぐい
        private void Check(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
        {
            foreach (var value in propertiesThatChanged.Values)
            {
                var id = value.ToString();
                if (_dic.ContainsKey(id))
                {
                    _dic[id] = true;
                }
            }
        }

        private ExitGames.Client.Photon.Hashtable GetCustomProperties(PropertyType type)
        {
            if (type == PropertyType.Room)
            {
                return PhotonNetwork.CurrentRoom.CustomProperties;
            }
            else
            {
                return PhotonNetwork.LocalPlayer.CustomProperties;
            }
        }

        private void SetCustomProperties(PropertyType type, ExitGames.Client.Photon.Hashtable cp)
        {
            if (type == PropertyType.Room)
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(cp);
            }
            else
            {
                PhotonNetwork.LocalPlayer.SetCustomProperties(cp);
            }
        }
    }
}
