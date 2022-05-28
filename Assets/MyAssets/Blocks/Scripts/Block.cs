using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

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
            _rigidbody = GetComponentInChildren<Rigidbody2D>();
            _colliders = GetComponentsInChildren<BoxCollider2D>();
            SetColliderEnabled(true);
            SetRigidbodySimulated(true);

            // TODO テストコード
            SetColor(Color.HSVToRGB(Random.value, 1, 1));
        }

        private void SetColor(Color color)
        {
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            foreach (var item in spriteRenderers)
            {
                item.color = color;
            }
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

        public async void Rotate()
        {
            var currentAngle = transform.eulerAngles;
            var targetAngle = currentAngle + new Vector3(0, 0, RotateAngle);
            await transform.DORotate(targetAngle, RotateDuration);
        }

        // ブロックの動きが一定以下になればtrue
        public bool IsStopped()
        {
            var isSleeping = _rigidbody.velocity.magnitude < 0.01f;
            return isSleeping;
        }

        // ブロックの最高点を計算
        // そこそこ重そうだから毎フレーム呼ぶのはやめといたほうがいいかも
        public float CalcMaxY()
        {
            var maxY = float.NegativeInfinity;

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
