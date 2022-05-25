using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        }

        public void FadeIn(float duration, System.Action completed = null)
        {
            _canvasGroup.DOKill();
            _canvasGroup.DOFade(0, duration).OnComplete(() => completed?.Invoke());
        }

        public void FadeOut(float duration, System.Action completed = null)
        {
            _canvasGroup.DOKill();
            _canvasGroup.DOFade(1, duration).OnComplete(() => completed?.Invoke());
        }
    }
}
