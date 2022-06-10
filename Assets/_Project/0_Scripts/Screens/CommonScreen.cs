using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.SelectMatchScreen
{
    public class CommonScreen : MonoBehaviour, IScreen, IStaticAwake
    {
        [Header("フェードイン前の初期化処理があれば登録(Async版もここに登録)")]
        [SerializeField] private GameObject _preInitializeStateObject;

        [Space(20)]
        [SerializeField] private ScreenType _screenType;
        [SerializeField] private GameObject _nextStateObject;

        public ScreenType Type => _screenType;

        private IPreInitializeState _preInitilizeState;
        private IPreInitializeStateAsync _preInitializeStateAsync;

        private IState _nextState;

        public void StaticAwake()
        {
            if (_preInitializeStateObject != null)
            {
                _preInitilizeState = _preInitializeStateObject.GetComponent<IPreInitializeState>();
                _preInitializeStateAsync = _preInitializeStateObject.GetComponent<IPreInitializeStateAsync>();
            }

            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async UniTask OpenAsync(float duration)
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            await Fader.Instance.FadeOutAsync(0);
            await PreInitializeState();

            await Fader.Instance.FadeInAsync(duration);
            _nextState.Enter();
        }

        public async UniTask CloseAsync(float duration)
        {
            if (!gameObject.activeSelf) return;

            await Fader.Instance.FadeOutAsync(duration);
            gameObject.SetActive(false);
        }

        private async UniTask PreInitializeState()
        {
            if (_preInitilizeState != null)
            {
                _preInitilizeState.Enter();
            }
            if (_preInitializeStateAsync != null)
            {
                await _preInitializeStateAsync.Enter();
            }
        }
    }
}
