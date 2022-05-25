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

        public MaxHeight CalcMaxHeight()
        {
            var maxHeight = MaxHeight.Min;

            foreach (var block in blocks)
            {
                var height = block.CalcMaxHeight();
                if (height.value > maxHeight)
                {
                    maxHeight = height.value;
                }
            }

            return new MaxHeight(maxHeight);
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
