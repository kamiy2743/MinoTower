using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.Block
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockType _blockType;

        public BlockType BlockType { get; private set; }

        private Rigidbody2D _rigidbody;
        private BoxCollider2D[] _colliders;

        void Awake()
        {
            BlockType = _blockType;
            _rigidbody = GetComponent<Rigidbody2D>();
            _colliders = GetComponentsInChildren<BoxCollider2D>();
        }

        public void ToColliderEnable()
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = true;
            }
        }

        public void ToColliderDisable()
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = false;
            }
        }

        // ブロックの動きが一定以下になればtrue
        public bool IsStop()
        {
            return _rigidbody.IsSleeping();
        }

        // ブロックの最高点を計算
        // そこそこ重そうだから毎フレーム呼ぶのはやめといたほうがいいかも
        public float CalcMaxY()
        {
            var maxY = transform.position.y;

            foreach (var collider in _colliders)
            {
                var mesh = collider.CreateMesh(true, true);

                foreach (var vert in mesh.vertices)
                {
                    if (vert.y > maxY)
                    {
                        maxY = vert.y;
                    }
                }
            }

            return maxY;
        }
    }
}
