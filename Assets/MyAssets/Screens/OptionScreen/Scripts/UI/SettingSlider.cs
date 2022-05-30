using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MT.Util.UI;
using UnityEngine.Events;

namespace MT.Screens.OptionScreen.UI
{
    public class SettingSlider : MonoBehaviour, IInteractableUI
    {
        private Slider _slider;
        private bool _isInteractable;

        void Awake()
        {
            _slider = GetComponentInChildren<Slider>();
        }

        public void SetInteractable(bool value)
        {
            _slider.interactable = value;
            _isInteractable = value;
        }

        public void Initialize(float initValue)
        {
            _slider.value = initValue;
        }

        public void OnValueChangedAddListener(UnityAction<float> call)
        {
            _slider.onValueChanged.AddListener(call);
        }
    }
}
