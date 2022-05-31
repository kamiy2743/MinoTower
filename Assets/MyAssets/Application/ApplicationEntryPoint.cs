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
            StaticAwakeCaller.Call();
            StaticStartCaller.Call();

            _firstOpenScreen.Execute();
        }
    }
}
