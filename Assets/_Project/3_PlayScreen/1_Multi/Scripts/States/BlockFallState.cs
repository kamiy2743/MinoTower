using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Multi
{
    public class BlockFallState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private ActiveBlockProvider _activeBlockProvider;
        [SerializeField] private PlayerTurnProvider _playerTurnProvider;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            if (_playerTurnProvider.IsMyTurn())
            {
                _activeBlockProvider.Get().StartFall();
            }

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

