using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Extension;

namespace MT.Inputs
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private EventTrigger _trigger;
        [SerializeField] private Button _rotateButton;

        // InputSystemを使えばこんな状態変数いらない
        private bool isDrag;
        private bool isDrop;
        private bool isRotateButtonClicked;

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

            _rotateButton.onClick.AddListener(() =>
            {
                isRotateButtonClicked = true;
            });
        }

        void LateUpdate()
        {
            isDrop = false;
            isRotateButtonClicked = false;
        }

        public bool MoveBlock()
        {
            return isDrag;
        }

        public bool RotateBlock()
        {
            return isRotateButtonClicked;
        }

        public bool DropBlock()
        {
            return isDrop;
        }
    }
}
