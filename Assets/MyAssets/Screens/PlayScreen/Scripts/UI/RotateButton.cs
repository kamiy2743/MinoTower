using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT.Screens.PlayScreen.UI
{
    public class RotateButton : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private float _hideDuration;

        private CanvasGroup _canvasGroup;

        public void StaticAwake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Initialize()
        {
            ShowImmediately();
        }

        public void ShowImmediately()
        {
            _canvasGroup.DOKill();
            _canvasGroup.alpha = 1;
        }

        public async void Hide()
        {
            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(0, _hideDuration);
        }
    }
}
