using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Audio;

namespace MT.Application
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        void Start()
        {
            StaticAwakeCaller.Call();
            StaticStartCaller.Call();
        }
    }
}
