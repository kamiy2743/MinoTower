using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.OptionScreen.UI;
using MT.Audio;

namespace MT.Screens.OptionScreen.Systems
{
    public class AudioSettingApplier : MonoBehaviour
    {
        [SerializeField] private SettingSlider _BGMSlider;
        [SerializeField] private SettingSlider _SESlider;

        void Start()
        {
            _BGMSlider.OnValueChangedAddListener(ApplyBGMVolume);
            _SESlider.OnValueChangedAddListener(ApplySEVolume);
        }

        public void Initialize()
        {
            _BGMSlider.Initialize(AudioManager.Instance.DefaultBGMVolume);
            ApplyBGMVolume(AudioManager.Instance.DefaultBGMVolume);

            _SESlider.Initialize(AudioManager.Instance.DefaultSEVolume);
            ApplySEVolume(AudioManager.Instance.DefaultSEVolume);
        }

        private void ApplyBGMVolume(float value)
        {
            AudioManager.Instance.SetBGMVolume(value);
        }

        private void ApplySEVolume(float value)
        {
            AudioManager.Instance.SetSEVolume(value);
        }
    }
}