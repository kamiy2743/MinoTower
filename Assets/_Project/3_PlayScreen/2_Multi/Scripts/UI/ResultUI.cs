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

        private CommonUI _commonUI;

        public void StaticAwake()
        {
            _commonUI = GetComponent<CommonUI>();
        }

        public async UniTask ShowAsync(float fadeDuration)
        {
            await _commonUI.ShowAsync(fadeDuration);
        }

        public async UniTask HideAsync(float fadeDuration)
        {
            await _commonUI.HideAsync(fadeDuration);
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
