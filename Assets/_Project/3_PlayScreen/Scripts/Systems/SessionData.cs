using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class SessionData : MonoBehaviour, IStaticAwake
    {
        // グローバル変数じゃないか
        public MaxHeight MaxHeight;

        public void StaticAwake()
        {
            Initialize();
        }

        public void Initialize()
        {
            MaxHeight = MaxHeight.Min;
        }
    }
}
