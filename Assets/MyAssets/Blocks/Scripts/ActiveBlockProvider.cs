using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MT.Blocks
{
    public class ActiveBlockProvider : MonoBehaviour
    {
        [SerializeField] private BlockStore _blockStore;

        public Block Get()
        {
            return _blockStore.Blocks().Last();
        }
    }
}
