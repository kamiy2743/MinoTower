using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Single
{
    public class ResultUI : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private CustomText _maxHeightText;

        private CommonUI _commonUI;

        public void StaticAwake()
        {
            _commonUI = GetComponentInChildren<CommonUI>();
        }

        public void Initialize()
        {
            HideAsync(0).Forget();
        }

        public async UniTask ShowAsync(float fadeDuration)
        {
            await _commonUI.ShowAsync(fadeDuration);
        }

        public async UniTask HideAsync(float fadeDuration)
        {
            await _commonUI.HideAsync(fadeDuration);
        }

        public void SetMaxHeightText(float maxHeightValue)
        {
            var formattedHeight = Mathf.Floor(maxHeightValue * 10f) / 10f;
            _maxHeightText.SetText(formattedHeight.ToString() + "m");
        }
    }
}
