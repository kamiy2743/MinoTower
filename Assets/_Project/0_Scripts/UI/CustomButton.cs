using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MT
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, ICustomEvent, IStaticAwake, IStaticStart
    {
        [SerializeField] private bool _startToListend = false;
        [SerializeField] private SEType _clickedSE;

        private CanvasGroup _canvasGroup;

        private CustomEvent _customEvent = new CustomEvent();

        public void StaticAwake()
        {
            SetIsListened(_startToListend);
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void StaticStart()
        {
            AddListener(() =>
            {
                AudioPlayer.Instance.PlaySE(_clickedSE);
            });
        }

        public void SetIsListened(bool value)
        {
            _customEvent.SetIsListened(value);
        }

        public void AddListener(UnityAction call)
        {
            _customEvent.AddListener(call);
        }

        public void OnClickedSE(SEType type)
        {
            _clickedSE = type;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _customEvent.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_customEvent.IsListened) return;

            transform.DOScale(0.95f, 0.24f).SetEase(Ease.OutCubic);
            _canvasGroup.DOFade(0.8f, 0.24f).SetEase(Ease.OutCubic);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOScale(1f, 0.24f).SetEase(Ease.OutCubic);
            _canvasGroup.DOFade(1f, 0.24f).SetEase(Ease.OutCubic);
        }
    }
}
