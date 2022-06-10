using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using Pun2Task;
using Photon.Realtime;


namespace MT.PlayScreen.Single
{
    public class PreInitializeState : MonoBehaviour, IPreInitializeState
    {
        [Header("初期化対象")]
        [SerializeField] private RandomProvider _randomProvider;
        [SerializeField] private SessionData _sessionData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;
        [SerializeField] private ResultEffect _resultEffect;

        public void Enter()
        {
            PhotonUtil.OfflineMode();

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
