using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens;

namespace MT.Application
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenSwitcher _screenSwitcher;

        void Start()
        {
            StaticAwakeCaller.Call();
            StaticStartCaller.Call();

            _screenSwitcher.Initialize();
        }
    }
}
