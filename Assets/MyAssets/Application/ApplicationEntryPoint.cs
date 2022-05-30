using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Audio;

namespace MT.Application
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        [SerializeField] private FirstOpenScreen _firstOpenScreen;
        void Start()
        {
            _firstOpenScreen.Execute();
            AudioManager.Instance.Initialize();
        }
    }
}
