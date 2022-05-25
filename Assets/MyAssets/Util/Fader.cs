using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MT.Util
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _ui;

        public static Fader Instance => _instance;
        private static Fader _instance;

        void Awake()
        {
            _instance = this;
        }

        public void FadeIn(float duration, float endValue = 0, System.Action completed = null)
        {
            _ui.DOKill();
            _ui.DOFade(endValue, duration).OnComplete(() => completed?.Invoke());
        }

        public void FadeOut(float duration, float endValue = 1, System.Action completed = null)
        {
            _ui.DOKill();
            _ui.DOFade(endValue, duration).OnComplete(() => completed?.Invoke());
        }
    }
}
