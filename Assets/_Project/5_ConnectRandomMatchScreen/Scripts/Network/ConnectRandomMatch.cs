using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.ConnectRandomMatchScreen
{
    public class ConnectRandomMatch : MonoBehaviour, IConnectMatch
    {
        public async UniTask<bool> TryConnect()
        {
            await UniTask.Delay(3000);
            return true;
        }

        public async UniTask Disconnect()
        {
            await UniTask.Delay(100);
        }
    }
}
