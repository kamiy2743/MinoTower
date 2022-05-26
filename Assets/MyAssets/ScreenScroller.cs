using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            SetScroll(ScrollAmount.Min);
        }

        public void SetScroll(ScrollAmount scrollAmount)
        {
            _scrollAmount = scrollAmount;

            var pos = _cameraTransfrom.position;
            pos.y = scrollAmount.value;
            _cameraTransfrom.position = pos;
        }
    }
}
