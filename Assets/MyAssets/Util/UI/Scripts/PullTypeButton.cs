using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Util.UI
{
    public class PullTypeButton : MonoBehaviour, IPullTypeButton
    {
        private bool _isClicked;

        void Awake()
        {
            var button = GetComponent<CustomButton>();
            button.AddListener(() => _isClicked = true);
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
