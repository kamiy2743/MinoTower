using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens.OptionScreen.UI;
using MT.Audio;

namespace MT.Screens.OptionScreen.Systems
{
    public class AudioSettingApplier : MonoBehaviour, IStaticStart, IInitializable
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
            _BGMSlider.SetValue(AudioManager.Instance.GetBGMVolume());
            _SESlider.SetValue(AudioManager.Instance.GetSEVolume());
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
