using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using MT.Audio;
using MT.Events;

namespace MT.Util.UI
{
    public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IEventListener, IStaticAwake
    {
        [SerializeField] private bool _startToListend = false;
        [SerializeField] private SEType _clickedSE;

        private CanvasGroup _canvasGroup;

        private EventSubject _eventSubject = new EventSubject();

        public void StaticAwake()
        {
            SetIsListened(_startToListend);
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void SetIsListened(bool value)
        {
            _eventSubject.SetIsListened(value);
        }

        public void AddListener(UnityAction call)
        {
            _eventSubject.AddListener(call);
        }

        public void OnClickedSE(SEType type)
        {
            _clickedSE = type;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _eventSubject.Invoke();
            AudioManager.Instance.PlaySE(_clickedSE);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_eventSubject.IsListened) return;

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
