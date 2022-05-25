using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MT.Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockType _blockType;

        public BlockType BlockType => _blockType;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D[] _colliders;

        private static float RotateAngle = -45;
        private static float RotateDuration = 0.1f;


        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _colliders = GetComponentsInChildren<BoxCollider2D>();
            SetColliderEnabled(true);
            SetRigidbodySimulated(true);
        }

        public void OnSpwned()
        {
            SetColliderEnabled(false);
            SetRigidbodySimulated(false);
        }

        public void StartFall()
        {
            SetColliderEnabled(true);
            SetRigidbodySimulated(true);
        }

        private void SetColliderEnabled(bool enabled)
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = enabled;
            }
        }

        private void SetRigidbodySimulated(bool simulated)
        {
            _rigidbody.simulated = simulated;
        }

        public void Rotate()
        {
            var currentAngle = transform.eulerAngles;
            var targetAngle = currentAngle + new Vector3(0, 0, RotateAngle);
            transform.DORotate(targetAngle, RotateDuration);
        }

        // ブロックの動きが一定以下になればtrue
        public bool IsStop()
        {
            return _rigidbody.IsSleeping();
        }

        // ブロックの最高点を計算
        // そこそこ重そうだから毎フレーム呼ぶのはやめといたほうがいいかも
        public MaxHeight CalcMaxHeight()
        {
            var maxHeight = MaxHeight.Min;

            foreach (var collider in _colliders)
            {
                var mesh = collider.CreateMesh(true, true);

                foreach (var vert in mesh.vertices)
                {
                    if (vert.y > maxHeight)
                    {
                        maxHeight = vert.y;
                    }
                }
            }

            return new MaxHeight(maxHeight);
        }
    }
}
