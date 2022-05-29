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

        private static float SpawnAnimationDuration = 0.5f;
        private static float RotateAngle = -45;
        private static float RotateDuration = 0.5f;


        void Awake()
        {
            _rigidbody = GetComponentInChildren<Rigidbody2D>();
            _colliders = GetComponentsInChildren<BoxCollider2D>();
            SetColliderEnabled(true);
            SetRigidbodySimulated(true);
            SetColor(Color.HSVToRGB(Random.value, Random.Range(0.3f, 1f), Random.Range(0.8f, 1f)));
        }

        private void SetColor(Color color)
        {
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            foreach (var item in spriteRenderers)
            {
                item.color = color;
            }
        }

        public async UniTask OnSpwned()
        {
            SetColliderEnabled(false);
            SetRigidbodySimulated(false);
            await SpawnAnimation();
        }

        private async UniTask SpawnAnimation()
        {
            transform.localScale = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 360 - 45);

            await DOTween.Sequence()
                .Append(transform.DOScale(Vector3.one, SpawnAnimationDuration).SetEase(Ease.OutBack))
                .Join(transform.DORotate(Vector3.zero, SpawnAnimationDuration));
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
