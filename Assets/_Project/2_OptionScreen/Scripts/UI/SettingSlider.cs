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
        private CustomEvent<float> _eventSubject = new CustomEvent<float>();

        public void StaticAwake()
        {
            _slider = GetComponentInChildren<Slider>();
            _slider.onValueChanged.AddListener(value => _eventSubject.Invoke(value));
        }

        public void SetIsListened(bool value)
        {
            _slider.interactable = value;
            _eventSubject.SetIsListened(value);
        }

        public void AddListener(UnityAction<float> call)
        {
            _eventSubject.AddListener(call);
        }

        public void SetValue(float value)
        {
            _slider.value = value;
        }
    }
}
