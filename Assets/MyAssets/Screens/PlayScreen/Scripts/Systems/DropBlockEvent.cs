using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MT.Screens.PlayScreen.Systems
{
    public class DropBlockEvent : MonoBehaviour, IInteractableUI, IStaticStart
    {
        private bool _isInteractable = false;
        private UnityEvent _onDropBlovk = new UnityEvent();

        public void StaticStart()
        {
            UIEvent.Instance.AddListener(EventTriggerType.PointerUp, OnDropBlock);
        }

        public void SetInteractable(bool value)
        {
            _isInteractable = value;
        }

        public void AddListener(UnityAction call)
        {
            _onDropBlovk.AddListener(call);
        }

        private void OnDropBlock()
        {
            if (!_isInteractable) return;

            _onDropBlovk.Invoke();
        }
    }
}
