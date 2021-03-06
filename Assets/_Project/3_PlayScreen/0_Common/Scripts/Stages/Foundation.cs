using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class Foundation : MonoBehaviour, IStaticAwake
    {
        private BoxCollider2D _collider;

        public void StaticAwake()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        public float GetTop()
        {
            var center = _collider.bounds.center;
            var extents = _collider.bounds.extents;
            return center.y + extents.y;
        }
    }
}
