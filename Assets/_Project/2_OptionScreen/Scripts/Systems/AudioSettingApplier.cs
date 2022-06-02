using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.OptionScreen
{
    public class AudioSettingApplier : MonoBehaviour, IStaticStart
    {
        [SerializeField] private SettingSlider _BGMSlider;
        [SerializeField] private SettingSlider _SESlider;

        public void StaticStart()
        {
            _BGMSlider.AddListener(ApplyBGMVolume);
            _SESlider.AddListener(ApplySEVolume);
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
