using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MT.Screens.PlayScreen.Systems
{
    public class MoveBlockEvent : MonoBehaviour, IInteractableUI, IStaticStart
    {
        private bool _isInteractable = false;
        private UnityEvent _onMoveBlovk = new UnityEvent();

        public void StaticStart()
        {
            UIEvent.Instance.AddListener(EventTriggerType.PointerDown, OnMoveBlock);
            UIEvent.Instance.AddListener(EventTriggerType.Drag, OnMoveBlock);
        }

        public void SetInteractable(bool value)
        {
            _isInteractable = value;
        }

        public void AddListener(UnityAction call)
        {
            _onMoveBlovk.AddListener(call);
        }

        private void OnMoveBlock()
        {
            if (!_isInteractable) return;

            _onMoveBlovk.Invoke();
        }
    }
}
