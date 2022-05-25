using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

namespace MT.PlayScreen
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

        public void Show(bool immediately = false, System.Action completed = null)
        {
            _maxHeight.text = _playData.MaxHeight.value.ToString();
            var fadeDuration = immediately ? 0 : _fadeDuration;

            _ui.interactable = true;
            _ui.blocksRaycasts = true;
            _ui.DOFade(1, fadeDuration).OnComplete(() => completed?.Invoke());
        }

        public void Hide(bool immediately = false, System.Action completed = null)
        {
            var fadeDuration = immediately ? 0 : _fadeDuration;

            _ui.interactable = false;
            _ui.blocksRaycasts = false;
            _ui.DOFade(0, fadeDuration).OnComplete(() => completed?.Invoke());
        }
    }
}
