using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;

namespace MT.ConnectRandomMatchScreen
{
    public class PreInitializeState : MonoBehaviour, IPreInitializeState
    {
        [Header("初期化対象")]
        [SerializeField] private LoadingUI _loadingUI;

        public void Enter()
        {
            _loadingUI.ShowAsync(0).Forget();
        }
    }
}
