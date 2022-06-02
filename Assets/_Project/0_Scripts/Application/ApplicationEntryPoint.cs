using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
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
