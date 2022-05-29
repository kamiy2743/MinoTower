using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClipStore _audioClipStore;
        [SerializeField] private AudioSource _BGMSource;
        [SerializeField] private AudioSource _SESource;
        [SerializeField] private float _defaultBGMVolume;
        [SerializeField] private float _defaultSEVolume;

        public float DefaultBGMVolume => _defaultBGMVolume;
        public float DefaultSEVolume => _defaultSEVolume;

        public static AudioManager Instance => _isntance;
        private static AudioManager _isntance;

        void Awake()
        {
            _isntance = this;
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
        }

        public void SetSEVolume(float value)
        {
            _SESource.volume = value;
        }
    }
}
