using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Screens;

namespace MT.Application
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        void Start()
        {
            new StaticAwakeCaller().Call();
            new StaticStartCaller().Call();

            ScreenSwitcher.Instance.Initialize();
        }
    }
}
