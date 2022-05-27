using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Blocks;

namespace MT.Screens.PlayScreen.Systems
{
    public class PlayData : MonoBehaviour
    {
        // グローバル変数じゃないか
        public MaxHeight MaxHeight;

        void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            MaxHeight = MaxHeight.Min;
        }
    }
}