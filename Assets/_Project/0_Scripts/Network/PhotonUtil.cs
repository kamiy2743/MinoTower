using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;
using Photon.Pun;

namespace MT
{
    public static class PhotonUtil
    {
        public static async UniTask LeaveRoomAsync()
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.Log("not in room");
                return;
            }

            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            await Pun2TaskNetwork.LeaveRoomAsync();
            await Pun2TaskCallback.OnConnectedToMasterAsync();
            Debug.Log("leave");
        }
    }
}
