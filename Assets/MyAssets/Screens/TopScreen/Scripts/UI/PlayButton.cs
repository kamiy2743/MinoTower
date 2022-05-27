using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using UnityEngine.UI;

namespace MT.Screens.TopScreen.UI
{
    public class PlayButton : MonoBehaviour, IPullTypeButton
    {
        private bool _isClicked;

        void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(() => _isClicked = true);
        }

        void LateUpdate()
        {
            _isClicked = false;
        }

        public bool IsClicked()
        {
            return _isClicked;
        }
    }
}
