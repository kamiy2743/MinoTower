using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen
{
    public class ResultUI : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private CustomText _maxHeightText;
        [SerializeField] private float _fadeInDuration;

        private CanvasGroup _canvasGroup;

        public void StaticAwake()
        {
            _canvasGroup = GetComponentInChildren<CanvasGroup>();
        }

        public void Initialize()
        {
            HideImmediately();
        }

        public async void Show()
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(1, _fadeInDuration);
        }

        public void HideImmediately()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            _canvasGroup.DOKill();
            _canvasGroup.alpha = 0;
        }

        public void SetMaxHeightText(float maxHeightValue)
        {
            var formattedHeight = Mathf.Floor(maxHeightValue * 10f) / 10f;
            _maxHeightText.SetText(formattedHeight.ToString() + "m");
        }
    }
}
