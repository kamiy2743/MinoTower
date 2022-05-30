using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MT.Util.UI;
using Extension;
using UnityEngine.Events;

namespace MT.Screens.PlayScreen.Systems
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private EventTrigger _trigger;

        private Camera _mainCamera;

        void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void MoveBlockAddListener(UnityAction call)
        {
            _trigger.AddListener(EventTriggerType.PointerDown, call);
            _trigger.AddListener(EventTriggerType.Drag, call);
        }

        public void DropBlockAddListener(UnityAction call)
        {
            _trigger.AddListener(EventTriggerType.PointerUp, call);
        }

        public Vector2 PointerPosition()
        {
            return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
