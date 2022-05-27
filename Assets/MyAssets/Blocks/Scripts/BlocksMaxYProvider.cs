using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Blocks
{
    public class BlocksMaxYProvider : MonoBehaviour
    {
        [SerializeField] private BlockStore _blockStore;

        public float MaxY()
        {
            var maxY = float.NegativeInfinity;

            foreach (var block in _blockStore.Blocks())
            {
                var y = block.CalcMaxY();
                if (y > maxY)
                {
                    maxY = y;
                }
            }

            return maxY;
        }
    }
}
