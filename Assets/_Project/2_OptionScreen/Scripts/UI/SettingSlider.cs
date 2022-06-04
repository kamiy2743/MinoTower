using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace MT.OptionScreen
{
    public class SettingSlider : MonoBehaviour, ICustomEvent<float>, IStaticAwake
    {
        private Slider _slider;
        private CustomEvent<float> _customEvent = new CustomEvent<float>();

        public void StaticAwake()
        {
            _slider = GetComponentInChildren<Slider>();
            _slider.onValueChanged.AddListener(value => _customEvent.Invoke(value));
        }

        public void SetIsListened(bool value)
        {
            _slider.interactable = value;
            _customEvent.SetIsListened(value);
        }

        public void AddListener(UnityAction<float> call)
        {
            _customEvent.AddListener(call);
        }

        public void SetValue(float value)
        {
            _slider.value = value;
        }
    }
}
