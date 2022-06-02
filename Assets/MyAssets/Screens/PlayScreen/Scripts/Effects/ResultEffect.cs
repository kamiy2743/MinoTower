using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util.Effect;
using MT.Blocks;

namespace MT.Screens.PlayScreen.Effects
{
    public class ResultEffect : MonoBehaviour
    {
        [SerializeField] private PaperEffect _paperEffect;

        public void Initialize()
        {
            _paperEffect.Initialize();
        }

        public void Play(MaxHeight maxHeight)
        {
            var height = maxHeight.value;
            var ratio = height * 5f / 100f;
            _paperEffect.Play(ratio);
        }
    }
}
