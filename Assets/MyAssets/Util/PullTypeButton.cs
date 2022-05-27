using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MT.Util
{
    public class PullTypeButton : MonoBehaviour, IPullTypeButton
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
