using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Blocks
{
    public class MaxHeight
    {
        public static float Max = float.MaxValue;
        public static float Min = 0;

        public readonly float value;

        public MaxHeight(float height)
        {
            if (height > Max)
            {
                value = Max;
                return;
            }

            if (height < Min)
            {
                value = Min;
                return;
            }

            value = height;
        }
    }
}
