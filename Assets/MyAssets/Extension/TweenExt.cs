using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Extension
{
    public static class TweenExt
    {
        public static bool IsPlaying(this Tween tween)
        {
            var playings = DOTween.PlayingTweens();
            return playings.Contains(tween);
        }
    }
}