using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.SelectMatchScreen
{
    public class CommonScreen : MonoBehaviour, IScreen, IStaticAwake
    {
        [SerializeField] private GameObject _entryStateObject;
        [SerializeField] private ScreenType _screenType;

        public ScreenType Type => _screenType;

        private IState _entryState;

        public void StaticAwake()
        {
            _entryState = _entryStateObject.GetComponent<IState>();
        }

        public async UniTask OpenAsync(float duration)
        {
            if (gameObject.activeSelf) return;

            gameObject.SetActive(true);
            await Fader.Instance.FadeOutAsync(0);
            await Fader.Instance.FadeInAsync(duration);

            _entryState.Enter();
        }

        public async UniTask CloseAsync(float duration)
        {
            if (!gameObject.activeSelf) return;

            await Fader.Instance.FadeOutAsync(duration);
            gameObject.SetActive(false);
        }
    }
}
