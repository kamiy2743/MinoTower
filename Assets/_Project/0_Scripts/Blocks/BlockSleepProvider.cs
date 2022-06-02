using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Blocks
{
    public class BlockSleepProvider : MonoBehaviour
    {
        [SerializeField] private BlockStore _blockStore;

        public bool IsSleeping()
        {
            foreach (var block in _blockStore.Blocks())
            {
                if (!block.IsSleeping())
                    return false;
            }

            return true;
        }
    }
}
