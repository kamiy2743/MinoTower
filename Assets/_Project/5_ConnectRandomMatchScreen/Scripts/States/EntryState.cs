using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;

namespace MT.ConnectRandomMatchScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private LoadingUI _loadingUI;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(0);
            Initialize();

            await Fader.Instance.FadeInAsync(_fadeInDuration);
            _nextState.Enter();
        }

        private void Initialize()
        {
            _loadingUI.ShowAsync(0).Forget();
        }
    }
}
