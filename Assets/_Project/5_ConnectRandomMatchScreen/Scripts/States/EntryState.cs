using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;

namespace MT.ConnectRandomMatchScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private LoadingUI _loadingUI;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            Initialize();
            _nextState.Enter();
        }

        private void Initialize()
        {
            _loadingUI.ShowAsync(0).Forget();
        }
    }
}
