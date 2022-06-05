using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.MatchMakingScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private LoadingUI _loadingUI;
        [SerializeField] private SelectMatchUI _selectMatchUI;
        [SerializeField] private FriendMatchUI _friendMatchUI;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void EnterAsync()
        {
            await Fader.Instance.FadeOutAsync(0);
            Initialize();

            await Fader.Instance.FadeInAsync(_fadeInDuration);
            _nextState.EnterAsync();
        }

        private void Initialize()
        {
            _loadingUI.InitializeAsync();
            _selectMatchUI.InitializeAsync();
            _friendMatchUI.InitializeAsync();
        }
    }
}
