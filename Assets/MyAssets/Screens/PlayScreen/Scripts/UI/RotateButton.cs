using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using MT.Util;

namespace MT.Screens.PlayScreen.UI
{
    public class RotateButton : MonoBehaviour, IPullTypeButton
    {
        [SerializeField] private float _hideDuration;

        private CanvasGroup _canvasGroup;
        private bool _isClicked = false;

        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();

            var button = GetComponent<Button>();
            button.onClick.AddListener(() => _isClicked = true);
        }

        void LateUpdate()
        {
            _isClicked = false;
        }

        public void Initialize()
        {
            ShowImmediately();
        }

        public bool IsClicked()
        {
            return _isClicked;
        }

        public void ShowImmediately()
        {
            _canvasGroup.alpha = 1;
        }

        public async void Hide()
        {
            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(0, _hideDuration);
        }
    }
}
