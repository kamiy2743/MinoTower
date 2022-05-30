using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MT.Util.UI
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IInteractableUI, IStaticAwake
    {
        [SerializeField] private bool _startInteractable = false;

        private CanvasGroup _canvasGroup;
        private UnityEvent _onclickEvent = new UnityEvent();
        private bool _isInteractable = false;

        public void StaticAwake()
        {
            _isInteractable = _startInteractable;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void SetInteractable(bool vlaue)
        {
            _isInteractable = vlaue;
        }

        public void AddListener(UnityAction call)
        {
            _onclickEvent.AddListener(call);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_isInteractable) return;

            _onclickEvent.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isInteractable) return;

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
