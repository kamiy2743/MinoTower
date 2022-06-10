using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Pun2Task;
using Photon.Realtime;

namespace MT.PlayScreen.Single
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private RandomProvider _randomProvider;
        [SerializeField] private SessionData _sessionData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;
        [SerializeField] private ResultEffect _resultEffect;

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
            PhotonUtil.SetOfflineMode(true);

            _randomProvider.RandomForBlock = new CustomRandom();
            _sessionData.Initialize();
            _blockStore.Initialize();
            _resultUI.Initialize();
            _resultEffect.Initialize();
            _screenScroller.Initialize();
            _rotateButton.ShowAsync(0).Forget();
        }
    }
}
