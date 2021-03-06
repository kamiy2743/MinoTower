using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockConfig _blockConfig;

        private Rigidbody2D _rigidbody;
        private BoxCollider2D[] _colliders;

        private float _sleepingElapsed;

        // TODO 状態変数
        private bool _isColliderEnabled;

        public void OnCreate(CustomRandom random)
        {
            _rigidbody = GetComponentInChildren<Rigidbody2D>();
            _colliders = GetComponentsInChildren<BoxCollider2D>();
            SetColliderEnabled(true);
            SetRigidbodySimulated(true);

            SetColor(Color.HSVToRGB(random.Value(), random.Range(0.3f, 1f), random.Range(0.8f, 1f)));
        }

        private void SetColor(Color color)
        {
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            foreach (var item in spriteRenderers)
            {
                item.color = color;
            }
        }

        public async UniTask OnSpwnedAsync()
        {
            SetColliderEnabled(false);
            SetRigidbodySimulated(false);
            await SpawnAnimationAsync();
        }

        private async UniTask SpawnAnimationAsync()
        {
            transform.localScale = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 360 - 45);

            await DOTween.Sequence()
                .Append(transform.DOScale(Vector3.one, _blockConfig.SpawnAnimationDuration).SetEase(Ease.OutBack))
                .Join(transform.DORotate(Vector3.zero, _blockConfig.SpawnAnimationDuration));
        }

        public void StartFall()
        {
            SetColliderEnabled(true);
            SetRigidbodySimulated(true);
        }

        public void SetColliderEnabled(bool enabled)
        {
            _isColliderEnabled = enabled;
            foreach (var collider in _colliders)
            {
                collider.enabled = enabled;
            }
        }

        public void SetRigidbodySimulated(bool simulated)
        {
            _rigidbody.simulated = simulated;
        }

        public async UniTask RotateAsync()
        {
            var currentAngle = transform.eulerAngles;
            var targetAngle = currentAngle + new Vector3(0, 0, _blockConfig.RotateAngle);
            await transform.DORotate(targetAngle, _blockConfig.RotateDuration).SetEase(Ease.Linear);
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

            return _sleepingElapsed > _blockConfig.SleepThreshold;
        }

        // ブロックの最高点を計算
        // そこそこ重そうだから毎フレーム呼ぶのはやめといたほうがいいかも
        public float CalcMaxY()
        {
            var maxY = float.NegativeInfinity;

            // TODO 汚い
            var last = _isColliderEnabled;
            SetColliderEnabled(true);

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

            SetColliderEnabled(last);

            return maxY;
        }
    }
}
