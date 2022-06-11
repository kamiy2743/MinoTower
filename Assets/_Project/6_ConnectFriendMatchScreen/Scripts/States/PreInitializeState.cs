using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;

namespace MT.ConnectFriendMatchScreen
{
    public class PreInitializeState : MonoBehaviour, IPreInitializeState
    {
        [SerializeField] private FriendMatchRoomNameAccessor _friendMatchRoomNameAccessor;

        [Header("初期化対象")]
        [SerializeField] private RoomSettingUI _roomSettingUI;
        [SerializeField] private LoadingUI _loadingUI;

        public void Enter()
        {
            if (_friendMatchRoomNameAccessor.IsEmpty())
            {
                _roomSettingUI.ShowAsync(0).Forget();
                _loadingUI.HideAsync(0).Forget();
            }
            else
            {
                _roomSettingUI.HideAsync(0).Forget();
                _loadingUI.ShowAsync(0).Forget();
            }
        }
    }
}
