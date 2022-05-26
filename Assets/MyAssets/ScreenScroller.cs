using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

        public void SetScroll(ScrollAmount scrollAmount, float duration, System.Action completed = null)
        {
            _scrollAmount = scrollAmount;
            _cameraTransfrom.DOMoveY(scrollAmount.value, duration).OnComplete(() => completed?.Invoke());
        }
    }
}
