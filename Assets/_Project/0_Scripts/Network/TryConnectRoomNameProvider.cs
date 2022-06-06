using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class TryConnectRoomNameProvider : MonoBehaviour
    {
        [SerializeField] private CustomPropertyConfig _config;

        private async UniTask SetRoomName(string value)
        {
            await RoomPropertyAccessor.Instance.SetAsync<string>(_config.TryConnectRoomNameKey, value);
        }

        private string GetRoomName()
        {
            return RoomPropertyAccessor.Instance.Get<string>(_config.TryConnectRoomNameKey);
        }
    }
}
