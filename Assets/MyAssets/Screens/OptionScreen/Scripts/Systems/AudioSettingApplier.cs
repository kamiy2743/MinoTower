using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.OptionScreen.UI;
using MT.Audio;

namespace MT.Screens.OptionScreen.Systems
{
    public class AudioSettingApplier : MonoBehaviour, IStaticStart
    {
        [SerializeField] private SettingSlider _BGMSlider;
        [SerializeField] private SettingSlider _SESlider;

        public void StaticStart()
        {
            _BGMSlider.OnValueChangedAddListener(ApplyBGMVolume);
            _SESlider.OnValueChangedAddListener(ApplySEVolume);
        }

        public void Initialize()
        {
            _BGMSlider.Initialize(AudioManager.Instance.GetBGMVolume());
            _SESlider.Initialize(AudioManager.Instance.GetSEVolume());
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
