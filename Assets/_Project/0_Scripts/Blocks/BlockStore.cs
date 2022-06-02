using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class BlockStore : MonoBehaviour
    {
        private List<Block> _blocks = new List<Block>();

        public void Initialize()
        {
            foreach (var block in _blocks)
            {
                Destroy(block.gameObject);
            }

            _blocks.Clear();
        }

        public void Add(Block block)
        {
            _blocks.Add(block);
            block.transform.SetParent(this.transform);
        }

        public Block[] Blocks()
        {
            return _blocks.ToArray();
        }
    }
}
