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

            AudioPlayer.Instance.PlayBGM(BGMType.Main);
            ScreenSwitcher.Instance.Initialize();
            NetworkErrorObserver.Instance.Initialize();
        }
    }
}
