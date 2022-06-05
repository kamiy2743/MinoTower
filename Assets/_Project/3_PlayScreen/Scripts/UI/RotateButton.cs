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
        private CanvasGroup _canvasGroup;
        private CustomButton _customButton;

        public void StaticAwake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
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

        public async UniTask Show(float fadeDuration)
        {
            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(1, fadeDuration);
        }

        public async UniTask Hide(float fadeDuration)
        {
            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(0, fadeDuration);
        }
    }
}
