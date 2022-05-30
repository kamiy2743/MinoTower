using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Blocks;

namespace MT.Screens.PlayScreen.Systems
{
    public class PlayData : MonoBehaviour, IStaticAwake
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
