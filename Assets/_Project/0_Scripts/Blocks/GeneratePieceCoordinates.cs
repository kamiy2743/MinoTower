using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public partial class BlockFactory
    {
        private Vector2Int[] CreatePieceCoordinates(int pieceCount)
        {
            var coordinates = new List<Vector2Int>() { Vector2Int.zero };

            for (int i = 0; i < pieceCount - 1; i++)
            {
                var placableCoodinates = GetPlacableCoordinates(coordinates);
                var randIndex = Random.Range(0, placableCoodinates.Length);
                coordinates.Add(placableCoodinates[randIndex]);
            }

            return coordinates.ToArray();
        }

        private Vector2Int[] GetPlacableCoordinates(List<Vector2Int> original)
        {
            var coordinates = new List<Vector2Int>();

            foreach (var item in original)
            {
                var e = new Vector2Int(item.x + 1, item.y);
                var w = new Vector2Int(item.x - 1, item.y);
                var n = new Vector2Int(item.x, item.y + 1);
                var s = new Vector2Int(item.x, item.y - 1);

                if (!original.Contains(e)) coordinates.Add(e);
                if (!original.Contains(w)) coordinates.Add(w);
                if (!original.Contains(n)) coordinates.Add(n);
                if (!original.Contains(s)) coordinates.Add(s);
            }

            return coordinates.ToArray();
        }
    }
}
