using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Multi
{
    public class ResultUI : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private CustomText _winOrLoseText;
        [SerializeField] private CustomText _totalResultText;
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

        public async void ShowAsync()
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

        public void SetTotalResultText(int winCount, int loseCount)
        {
            _totalResultText.SetText(winCount + "勝" + loseCount + "敗");
        }

        public void SetWinOrLoseText(bool win)
        {
            var text = win ? "Win!" : "Lose";
            _winOrLoseText.SetText(text);
        }
    }
}
