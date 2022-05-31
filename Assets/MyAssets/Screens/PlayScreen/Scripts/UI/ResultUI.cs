using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using MT.Util.UI;

namespace MT.Screens.PlayScreen.UI
{
    public class ResultUI : MonoBehaviour, IInitializable
    {
        [SerializeField] private CanvasGroup _ui;
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private CustomText _maxHeight;

        public void Initialize()
        {
            HideImmediately();
        }

        public async void Show()
        {
            _ui.interactable = true;
            _ui.blocksRaycasts = true;
            await _ui.DOFade(1, _fadeInDuration);
        }

        public void HideImmediately()
        {
            _ui.interactable = false;
            _ui.blocksRaycasts = false;
            _ui.DOKill();
            _ui.alpha = 0;
        }

        public void SetMaxHeightText(float maxHeightValue)
        {
            var formattedHeight = Mathf.Floor(maxHeightValue * 10f) / 10f;
            _maxHeight.SetText(formattedHeight.ToString() + "m");
        }
    }
}
