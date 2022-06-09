using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT
{
    public interface IMatchMaker
    {
        /// <returns>Success</returns>
        UniTask<bool> TryConnect();
        UniTask Disconnect();
    }
}
