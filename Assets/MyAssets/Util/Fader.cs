using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT.Util
{
    public class Fader : MonoBehaviour
    {
        public static Fader Instance => _instance;
        private static Fader _instance;

        private CanvasGroup _canvasGroup;

        void Awake()
        {
            _instance = this;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public async UniTask FadeIn(float duration)
        {
            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(0, duration);
        }

        public async UniTask FadeOut(float duration)
        {
            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(1, duration);
        }
    }
}
