using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public partial class BlockFactory
    {
        private class BlockPieceContainer
        {
            private Transform _container;
            private List<BlockPiece> _pieces = new List<BlockPiece>();

            public BlockPieceContainer()
            {
                _container = new GameObject("BlockPieceContainer").transform;
                _container.position = Vector3.zero;
            }

            public void Add(BlockPiece piece)
            {
                _pieces.Add(piece);
                piece.transform.SetParent(_container);
            }

            public Vector2 GetCenterOfMass()
            {
                float sumX = 0;
                float sumY = 0;

                foreach (var piece in _pieces)
                {
                    sumX += piece.transform.localPosition.x;
                    sumY += piece.transform.localPosition.y;
                }

                var centerX = sumX / _pieces.Count;
                var centerY = sumY / _pieces.Count;

                return new Vector2(centerX, centerY);
            }

            public void SetToBlock(Block block)
            {
                _container.SetParent(block.transform);
                _container.localPosition = GetCenterOfMass() * -1;
            }
        }
    }
}
