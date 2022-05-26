using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Blocks
{
    public class MaxHeight
    {
        private static float maxValue = float.MaxValue;
        private static float minValue = 0;

        public readonly float value;
        public static MaxHeight Max = new MaxHeight(maxValue);
        public static MaxHeight Min = new MaxHeight(minValue);

        public MaxHeight(float height)
        {
            if (height > maxValue)
            {
                value = maxValue;
                return;
            }

            if (height < minValue)
            {
                value = minValue;
                return;
            }

            value = height;
        }
    }
}
