using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace MT.PlayScreen
{
    public class RotateButton : MonoBehaviour, IStaticAwake, ICustomEvent
    {
        private CommonUI _commonUI;
        private CustomButton _customButton;

        public void StaticAwake()
        {
            _commonUI = GetComponent<CommonUI>();
            _customButton = GetComponent<CustomButton>();
        }

        public void SetIsListened(bool value)
        {
            _customButton.SetIsListened(value);
        }

        public void AddListener(UnityAction call)
        {
            _customButton.AddListener(call);
        }

        public async UniTask ShowAsync(float fadeDuration)
        {
            await _commonUI.ShowAsync(fadeDuration);
        }

        public async UniTask HideAsync(float fadeDuration)
        {
            await _commonUI.HideAsync(fadeDuration);
        }
    }
}
