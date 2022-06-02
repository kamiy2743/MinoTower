using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockType _blockType;

        public BlockType BlockType => _blockType;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D[] _colliders;

        private const float SpawnAnimationDuration = 0.4f;
        private const float RotateAngle = -45;
        private const float RotateDuration = 0.2f;
        private const float SleepThreshold = 0.3f;

        private float _sleepingElapsed;

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

        public async UniTask Rotate()
        {
            var currentAngle = transform.eulerAngles;
            var targetAngle = currentAngle + new Vector3(0, 0, RotateAngle);
            await transform.DORotate(targetAngle, RotateDuration).SetEase(Ease.Linear);
        }

        // ブロックの動きが一定以下になればtrue
        public bool IsSleeping()
        {
            var stopInThisFrame = _rigidbody.velocity.magnitude < 0.01f;
            if (stopInThisFrame)
            {
                _sleepingElapsed += Time.deltaTime;
            }
            else
            {
                _sleepingElapsed = 0;
            }

            return _sleepingElapsed > SleepThreshold;
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
