using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MT.Screens.OptionScreen.UI
{
    public class SettingSlider : MonoBehaviour
    {
        private Slider _slider;

        void Awake()
        {
            _slider = GetComponentInChildren<Slider>();
        }

        public void SetInteractable(bool interactable)
        {

        }

        public void SetValue(float value)
        {
            _slider.value = value;
        }

        public float GetValue()
        {
            return _slider.value;
        }
    }
}
