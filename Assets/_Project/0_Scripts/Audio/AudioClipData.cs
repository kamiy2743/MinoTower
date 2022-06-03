using UnityEngine;

namespace MT
{
    [CreateAssetMenu(fileName = "AudioClipData", menuName = "ScriptableObjects/AudioClipDatas")]
    public class AudioClipData : ScriptableObject
    {
        public BGMClip[] BGMClips;
        public SEClip[] SEClips;
    }
}