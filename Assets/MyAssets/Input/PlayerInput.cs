using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MT.Input
{
    public class PlayerInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private EventTrigger _trigger;
        [SerializeField] private Button _rotateButton;

        // InputSystemを使えばこんな状態変数いらないのに
        private bool isDrag;
        private bool isDrop;
        private bool isRotateButtonClicked;

        void Awake()
        {
            _trigger.AddListenner(EventTriggerType.Drag, () => isDrag = true);
            _trigger.AddListenner(EventTriggerType.Drop, () => isDrop = true);
            _rotateButton.onClick.AddListener(() => isRotateButtonClicked = true);
        }

        void Update()
        {
            Debug.Log("==============================");
            Debug.Log(MoveBlock());
            Debug.Log(RotateBlock());
            Debug.Log(DropBlock());
        }

        void LateUpdate()
        {
            isDrag = false;
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
