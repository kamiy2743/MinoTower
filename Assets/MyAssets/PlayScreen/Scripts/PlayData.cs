using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Blocks;

namespace MT.PlayScreen
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
            MaxHeight = new MaxHeight(MaxHeight.Min);
        }
    }
}
