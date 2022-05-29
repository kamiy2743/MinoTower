using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Application
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        [SerializeField] private FirstOpenScreen _firstOpenScreen;
        [SerializeField] private InitializeAudio _initializeAudio;

        void Start()
        {
            _firstOpenScreen.Execute();
            _initializeAudio.Execute();
        }
    }
}
