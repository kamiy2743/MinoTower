using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class PaperEffect : MonoBehaviour, IStaticAwake
    {
        [Header("0%")]
        [SerializeField] private float _minParticleCount;

        [Header("100%")]
        [SerializeField] private float _maxParticleCount;

        private ParticleSystem _particleSystem;

        public void StaticAwake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            Initialize();
        }

        public void Initialize()
        {
            _particleSystem.Clear();
            SetRateOverTime(0);
        }

        public void Play(float ratio)
        {
            SetParticleCount(ratio);
            _particleSystem.Play();
        }

        private void SetParticleCount(float ratio)
        {
            var particleCount = (_maxParticleCount - _minParticleCount) * ratio + _minParticleCount;

            var duration = _particleSystem.main.duration;
            SetRateOverTime(particleCount / duration);

            var main = _particleSystem.main;
            main.maxParticles = (int)particleCount;
        }

        private void SetRateOverTime(float value)
        {
            var emission = _particleSystem.emission;
            emission.rateOverTime = value;
        }
    }
}
