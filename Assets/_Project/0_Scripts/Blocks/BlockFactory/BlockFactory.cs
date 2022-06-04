using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Extension;

namespace MT
{
    public partial class BlockFactory : MonoBehaviour
    {
        [SerializeField] private Block _blockPrefab;
        [SerializeField] private BlockConfig _config;
        [SerializeField] private GameObject _blockPiecePrefab;

        public Block Create(Vector3 position, int pieceCount)
        {
            var pieceCoordinate = new PieceCoordinate(pieceCount);
            var blockPieceContainer = new BlockPieceContainer();

            foreach (var coord in pieceCoordinate.Values())
            {
                var blockPiece = new BlockPiece(_blockPiecePrefab, coord, _config.BlockScale);
                blockPieceContainer.Add(blockPiece);
            }

            return CreateBlock(position, blockPieceContainer);
        }

        private Block CreateBlock(Vector3 position, BlockPieceContainer container)
        {
            var block = Instantiate(_blockPrefab, position, Quaternion.identity);

            container.SetToBlock(block);
            block.OnCreate();

            return block;
        }
    }
}
