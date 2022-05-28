using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using Cysharp.Threading.Tasks;

namespace MT.Screens.PlayScreen.States
{
    public class BlockFallState : MonoBehaviour, IState
    {
        [SerializeField] private ActiveBlockProvider _activeBlockProvider;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            _activeBlockProvider.Get().StartFall();
            // 十分に落下して加速するまで待つ
            await UniTask.Delay(1000);
            ToNext();
        }

        public void ToNext()
        {
            _nextState.Enter();
        }
    }
}

