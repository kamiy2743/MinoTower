using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public partial class BlockFactory
    {
        private class BlockPiece
        {
            public Transform transform { get; private set; }

            public BlockPiece(GameObject prefab, Vector2Int pieceCoordinate, float scale)
            {
                var blockPiece = Instantiate(prefab, (Vector3)(Vector3Int)pieceCoordinate * scale, Quaternion.identity);
                blockPiece.transform.localScale = new Vector3(scale, scale, 1);

                transform = blockPiece.transform;
            }
        }
    }
}
