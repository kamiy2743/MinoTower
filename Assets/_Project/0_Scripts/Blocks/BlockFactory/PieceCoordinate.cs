using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public partial class BlockFactory
    {
        private class PieceCoordinate
        {
            private List<Vector2Int> _coordinates;

            public PieceCoordinate(int pieceCount)
            {
                var coordinates = new List<Vector2Int>() { Vector2Int.zero };

                for (int i = 0; i < pieceCount - 1; i++)
                {
                    var placableCoodinates = GetPlacableCoordinates(coordinates);
                    var randIndex = CustomRandom.Instance.Range(0, placableCoodinates.Count);
                    coordinates.Add(placableCoodinates[randIndex]);
                }

                _coordinates = coordinates;
            }

            private List<Vector2Int> GetPlacableCoordinates(List<Vector2Int> target)
            {
                var coordinates = new List<Vector2Int>();

                foreach (var item in target)
                {
                    var e = new Vector2Int(item.x + 1, item.y);
                    var w = new Vector2Int(item.x - 1, item.y);
                    var n = new Vector2Int(item.x, item.y + 1);
                    var s = new Vector2Int(item.x, item.y - 1);

                    if (!target.Contains(e)) coordinates.Add(e);
                    if (!target.Contains(w)) coordinates.Add(w);
                    if (!target.Contains(n)) coordinates.Add(n);
                    if (!target.Contains(s)) coordinates.Add(s);
                }

                return coordinates;
            }

            public Vector2Int[] Values()
            {
                return _coordinates.ToArray();
            }
        }
    }
}
