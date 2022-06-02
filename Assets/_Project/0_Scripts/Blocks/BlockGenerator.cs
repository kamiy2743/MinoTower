using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class BlockGenerator : MonoBehaviour
    {
        [SerializeField] private Block[] _blockPrefabs;

        public Block RandomGenerate(Vector3 position, Quaternion rotation)
        {
            var randIndex = Random.Range(0, _blockPrefabs.Length);
            var prefab = _blockPrefabs[randIndex];
            return Instantiate(prefab, position, rotation);
        }
    }
}
