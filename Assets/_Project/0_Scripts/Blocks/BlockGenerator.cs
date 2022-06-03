using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Extension;

namespace MT
{
    public class BlockGenerator : MonoBehaviour
    {
        [SerializeField] private Block _blockPrefab;
        [SerializeField] private BlockConfig _blockConfig;
        [SerializeField] private GameObject _blockPiecePrefab;

        public Block Generate(Vector3 position, int pieceCount)
        {
            var pieceCoordinates = GeneratePieceCoordinates();
            var blockPieceContainer = GenerateBlockPieceContainer();
            foreach (var coord in pieceCoordinates)
            {
                GenerateBlockPiece(coord, blockPieceContainer.transform);
            }

            return GenerateBlock(blockPieceContainer, position);
        }

        private Vector2Int[] GeneratePieceCoordinates()
        {
            return new Vector2Int[] {
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                new Vector2Int(0, 3)
             };
        }

        private GameObject GenerateBlockPieceContainer()
        {
            var blockPieceContainer = new GameObject("BlockPieceContainer");
            return blockPieceContainer;
        }

        private void GenerateBlockPiece(Vector2Int positionCoordinate, Transform parent)
        {
            var blockScale = _blockConfig.BlockScale;
            var blockPiece = Instantiate(_blockPiecePrefab, (Vector3)(Vector3Int)positionCoordinate * blockScale, Quaternion.identity, parent);
            blockPiece.transform.localScale = new Vector3(blockScale, blockScale, 1);
        }

        private Block GenerateBlock(GameObject blockPieceContainer, Vector3 position)
        {
            var block = Instantiate(_blockPrefab, position, Quaternion.identity);

            SetBlockPieceContainer(block.transform, blockPieceContainer.transform);

            block.OnGenerate();
            return block;
        }

        public void SetBlockPieceContainer(Transform block, Transform container)
        {
            container.transform.SetParent(block);

            var pieces = container.transform.GetChildrenRecursive();
            float sumX = 0;
            float sumY = 0;

            foreach (var piece in pieces)
            {
                sumX += piece.localPosition.x;
                sumY += piece.localPosition.y;
            }

            var centerX = sumX / pieces.Length;
            var centerY = sumY / pieces.Length;

            container.localPosition = new Vector3(centerX, centerY, 0) * -1;
        }
    }
}
