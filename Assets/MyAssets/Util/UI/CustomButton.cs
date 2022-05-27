using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MT.Util.UI
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        private CanvasGroup _canvasGroup;
        private bool _isClicked;
        private UnityEvent _onclickEvent = new UnityEvent();

        void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void AddListenner(UnityAction call)
        {
            _onclickEvent.AddListener(call);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _onclickEvent.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
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
