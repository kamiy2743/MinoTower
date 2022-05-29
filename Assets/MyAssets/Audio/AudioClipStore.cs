using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Audio
{
    public class AudioClipStore : MonoBehaviour
    {
        [SerializeField] private BGMClip[] _BGMClips;
        [SerializeField] private SEClip[] _SEClips;

        private Dictionary<BGMType, AudioClip> _BGMDictionary = new Dictionary<BGMType, AudioClip>();
        private Dictionary<SEType, AudioClip> _SEDictionary = new Dictionary<SEType, AudioClip>();

        void Awake()
        {
            foreach (var item in _BGMClips)
            {
                _BGMDictionary[item.Type] = item.Clip;
            }

            foreach (var item in _SEClips)
            {
                _SEDictionary[item.Type] = item.Clip;
            }
        }

        public AudioClip GetBGM(BGMType type)
        {
            return _BGMDictionary[type];
        }

        public AudioClip GetSE(SEType type)
        {
            return _SEDictionary[type];
        }
    }

    [System.Serializable]
    public class BGMClip
    {
        public BGMType Type;
        public AudioClip Clip;
    }

    [System.Serializable]
    public class SEClip
    {
        public SEType Type;
        public AudioClip Clip;
    }
}