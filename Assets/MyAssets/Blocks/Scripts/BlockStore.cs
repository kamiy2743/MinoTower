using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Blocks
{
    public class BlockStore : MonoBehaviour
    {
        private List<Block> blocks = new List<Block>();

        public void Add(Block block)
        {
            blocks.Add(block);
            block.transform.SetParent(this.transform);
        }

        public float CalcMaxY()
        {
            var maxY = float.NegativeInfinity;

            foreach (var block in blocks)
            {
                var y = block.CalcMaxY();
                if (y > maxY)
                {
                    maxY = y;
                }
            }

            return maxY;
        }

        public bool IsStop()
        {
            foreach (var block in blocks)
            {
                if (!block.IsStop())
                    return false;
            }

            return true;
        }
    }
}
