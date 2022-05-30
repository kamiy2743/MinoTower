using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Audio;

namespace MT.Application
{
    public class ApplicationEntryPoint : MonoBehaviour, IStaticStart
    {
        [SerializeField] private FirstOpenScreen _firstOpenScreen;
        public void StaticStart()
        {
            _firstOpenScreen.Execute();
            AudioManager.Instance.Initialize();
        }
    }
}
