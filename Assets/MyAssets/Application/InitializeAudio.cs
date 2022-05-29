using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Audio;

namespace MT.Application
{
    public class InitializeAudio : MonoBehaviour
    {
        public void Execute()
        {
            var audioManager = AudioManager.Instance;

            audioManager.SetBGMVolume(audioManager.DefaultBGMVolume);
            audioManager.SetSEVolume(audioManager.DefaultSEVolume);
        }
    }
}
