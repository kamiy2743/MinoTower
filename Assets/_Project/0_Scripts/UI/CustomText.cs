using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MT.Util.UI
{
    public class CustomText : MonoBehaviour, IStaticAwake
    {
        public string Text => _textMeshProUGUI.text;
        private TextMeshProUGUI _textMeshProUGUI;

        public void StaticAwake()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string text)
        {
            _textMeshProUGUI.text = text;
        }
    }
}
