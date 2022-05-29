using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Util.Effect
{
    public class PaperEffect : MonoBehaviour
    {
        [Header("0%")]
        [SerializeField] private float _minParticleCount;

        [Header("100%")]
        [SerializeField] private float _maxParticleCount;

        private ParticleSystem _particleSystem;

        void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            gameObject.SetActive(false);
        }

        public void Play(float ratio)
        {
            SetParticleCount(ratio);
            gameObject.SetActive(true);
            _particleSystem.Play();
        }

        private void SetParticleCount(float ratio)
        {
            var particleCount = (_maxParticleCount - _minParticleCount) * ratio + _minParticleCount;

            var emission = _particleSystem.emission;
            var duration = _particleSystem.main.duration;
            emission.rateOverTime = particleCount / duration;

            var main = _particleSystem.main;
            main.maxParticles = (int)particleCount;
        }

        void OnParticleSystemStopped()
        {
            gameObject.SetActive(false);
        }
    }
}
