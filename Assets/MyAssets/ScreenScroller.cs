using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class ScreenScroller : MonoBehaviour
    {
        public static ScreenScroller Instance => _instance;
        private static ScreenScroller _instance;

        private Transform _cameraTransfrom;
        private ScrollAmount _scrollAmount;

        void Awake()
        {
            _instance = this;
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
