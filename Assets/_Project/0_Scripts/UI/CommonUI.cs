using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class CommonUI : MonoBehaviour, IStaticAwake
    {
        private CanvasGroup _canvasGroup;

        public void StaticAwake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
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
