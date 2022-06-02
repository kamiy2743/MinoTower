using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class AudioClipStore : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private BGMClip[] _BGMClips;
        [SerializeField] private SEClip[] _SEClips;

        private Dictionary<BGMType, AudioClip> _BGMDictionary = new Dictionary<BGMType, AudioClip>();
        private Dictionary<SEType, AudioClip> _SEDictionary = new Dictionary<SEType, AudioClip>();

        // private static readonly AudioClip EmptyClip = AudioClip.Create("empty", 1, 1, 1, false, false);

        public void StaticAwake()
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
            // if (!_BGMDictionary.ContainsKey(type))
            // {
            //     Debug.LogWarning("クリップがありません");
            //     return EmptyClip;
            // }

            return _BGMDictionary[type];
        }

        public AudioClip GetSE(SEType type)
        {
            // if (!_SEDictionary.ContainsKey(type))
            // {
            //     Debug.LogWarning("クリップがありません");
            //     return EmptyClip;
            // }

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
