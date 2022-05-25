using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace MT.PlayScreen
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] private PlayData _playData;
        [SerializeField] private CanvasGroup _ui;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private TextMeshProUGUI _maxHeight;

        void Awake()
        {
            Hide(true);
        }

        public void Show(bool immediately = false)
        {
            _maxHeight.text = _playData.MaxHeight.value.ToString();
            var fadeDuration = immediately ? 0 : _fadeDuration;
            _ui.DOFade(1, fadeDuration);
        }

        public void Hide(bool immediately = false)
        {
            var fadeDuration = immediately ? 0 : _fadeDuration;
            _ui.DOFade(0, fadeDuration);
        }
    }
}
