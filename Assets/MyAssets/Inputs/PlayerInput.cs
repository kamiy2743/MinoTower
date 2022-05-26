using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MT.PlayScreen;
using Extension;

namespace MT.Inputs
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private EventTrigger _trigger;
        [SerializeField] private RotateButton _rotateButton;

        private Camera _mainCamera;

        // InputSystemを使えばこんな状態変数いらない
        private bool isDrag;
        private bool isDrop;

        void Awake()
        {
            _trigger.AddListenner(EventTriggerType.PointerDown, () =>
            {
                isDrag = true;
            });

            _trigger.AddListenner(EventTriggerType.PointerUp, () =>
            {
                isDrag = false;
                isDrop = true;
            });

            _mainCamera = Camera.main;
        }

        void LateUpdate()
        {
            isDrop = false;
        }

        public bool MoveBlock()
        {
            return isDrag;
        }

        public bool RotateBlock()
        {
            return _rotateButton.IsClicked();
        }

        public bool DropBlock()
        {
            return isDrop;
        }

        public Vector2 PointerPosition()
        {
            return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
