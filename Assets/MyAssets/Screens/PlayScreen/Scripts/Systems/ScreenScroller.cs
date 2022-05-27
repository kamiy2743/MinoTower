using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT.Screens.PlayScreen.Systems
{
    public class ScreenScroller : MonoBehaviour
    {
        private Transform _cameraTransfrom;
        private ScrollAmount _scrollAmount;

        void Awake()
        {
            _cameraTransfrom = Camera.main.transform;
            Initialize();
        }

        public void Initialize()
        {
            SetScroll(ScrollAmount.Min, 0);
        }

        public async UniTask SetScroll(ScrollAmount scrollAmount, float duration)
        {
            _scrollAmount = scrollAmount;
            await _cameraTransfrom.DOMoveY(scrollAmount.value, duration);
        }
    }
}