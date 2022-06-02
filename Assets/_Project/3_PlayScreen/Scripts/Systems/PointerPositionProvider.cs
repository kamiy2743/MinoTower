using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class PointerPositionProvider : MonoBehaviour, IStaticAwake
    {
        private Camera _mainCamera;

        public void StaticAwake()
        {
            _mainCamera = Camera.main;
        }

        public Vector2 Get()
        {
            return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
