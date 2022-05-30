using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Application.SaveData;

namespace MT.Audio
{
    public class AudioManager : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private AudioClipStore _audioClipStore;
        [SerializeField] private AudioSource _BGMSource;
        [SerializeField] private AudioSource _SESource;
        [SerializeField] private float _defaultBGMVolume;
        [SerializeField] private float _defaultSEVolume;

        public static AudioManager Instance => _isntance;
        private static AudioManager _isntance;

        private const string BGMVolumeKey = "BGMVolume";
        private const string SEVolumeKey = "SEVolume";

        public void StaticAwake()
        {
            _isntance = this;
        }

        public void Initialize()
        {
            var BGMVolume = SaveDataManager.Instance.Load<float>(BGMVolumeKey, _defaultBGMVolume);
            SetBGMVolume(BGMVolume);

            var SEVolume = SaveDataManager.Instance.Load<float>(SEVolumeKey, _defaultSEVolume);
            SetSEVolume(SEVolume);
        }

        public void PlayBGM(BGMType type)
        {
            var clip = _audioClipStore.GetBGM(type);

            var isPlaying = _BGMSource.isPlaying;
            var isSameClip = _BGMSource.clip == clip;
            if (isPlaying && isSameClip)
            {
                return;
            }

            _BGMSource.clip = clip;
            _BGMSource.Play();
        }

        public void PlaySE(SEType type)
        {
            var clip = _audioClipStore.GetSE(type);
            _SESource.PlayOneShot(clip);
        }

        public void SetBGMVolume(float value)
        {
            _BGMSource.volume = value;
            SaveDataManager.Instance.Save<float>(BGMVolumeKey, value);
        }

        public float GetBGMVolume()
        {
            return _BGMSource.volume;
        }

        public void SetSEVolume(float value)
        {
            _SESource.volume = value;
            SaveDataManager.Instance.Save<float>(SEVolumeKey, value);
        }

        public float GetSEVolume()
        {
            return _SESource.volume;
        }
    }
}
