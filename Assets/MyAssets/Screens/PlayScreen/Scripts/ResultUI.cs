using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace MT.Screens.PlayScreen
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] private PlayData _playData;
        [SerializeField] private CanvasGroup _ui;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private TextMeshProUGUI _maxHeight;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;

        public Button.ButtonClickedEvent ContinueButtonClick => _continueButton.onClick;
        public Button.ButtonClickedEvent ExitButtonClick => _exitButton.onClick;

        void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            Hide(true);
        }

        public async void Show(bool immediately = false)
        {
            SetMaxHeightText(_playData.MaxHeight.value);
            var fadeDuration = immediately ? 0 : _fadeDuration;

            _ui.interactable = true;
            _ui.blocksRaycasts = true;
            await _ui.DOFade(1, fadeDuration);
        }

        public async void Hide(bool immediately = false)
        {
            var fadeDuration = immediately ? 0 : _fadeDuration;

            _ui.interactable = false;
            _ui.blocksRaycasts = false;
            await _ui.DOFade(0, fadeDuration);
        }

        private void SetMaxHeightText(float maxHeightValue)
        {
            var formattedHeight = Mathf.Floor(maxHeightValue * 10f) / 10f;
            _maxHeight.text = formattedHeight.ToString() + "m";
        }
    }
}
