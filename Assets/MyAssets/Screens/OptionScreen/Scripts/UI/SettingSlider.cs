using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MT.Util.UI;
using UnityEngine.Events;

namespace MT.Screens.OptionScreen.UI
{
    public class SettingSlider : MonoBehaviour, IInteractableUI, IStaticAwake
    {
        private Slider _slider;
        private bool _isInteractable;

        public void StaticAwake()
        {
            _slider = GetComponentInChildren<Slider>();
        }

        public void SetInteractable(bool value)
        {
            _slider.interactable = value;
            _isInteractable = value;
        }

        public void SetValue(float value)
        {
            _slider.value = value;
        }

        public void OnValueChangedAddListener(UnityAction<float> call)
        {
            _slider.onValueChanged.AddListener(call);
        }
    }
}
