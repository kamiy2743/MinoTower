using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Blocks
{
    public class BlockGenerator : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private Block[] _blockPrefabs;

        private Dictionary<BlockType, Block> _prefabDic;

        public void StaticAwake()
        {
            _prefabDic = new Dictionary<BlockType, Block>();
            foreach (var item in _blockPrefabs)
            {
                _prefabDic[item.BlockType] = item;
            }
        }

        public Block RandomGenerate(Vector3 position, Quaternion rotation)
        {
            var type = (BlockType)Random.Range(0, _prefabDic.Keys.Count);
            return Generate(type, position, rotation);
        }

        public Block Generate(BlockType type, Vector3 position, Quaternion rotation)
        {
            var prefab = _prefabDic[type];
            return Instantiate(prefab, position, rotation);
        }
    }
}
