using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Blocks
{
    public class BlocksAllStoppedProvider : MonoBehaviour
    {
        [SerializeField] private BlockStore _blockStore;

        public bool IsAllStopped()
        {
            foreach (var block in _blockStore.Blocks())
            {
                if (!block.IsStopped())
                    return false;
            }

            return true;
        }
    }
}
