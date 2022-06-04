using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;


namespace MT.PlayScreen
{
    public class BlockSpawnState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private PlayScreenConfig _config;
        [SerializeField] private Transform _blockSpawnPoint;

        [Space(20)]
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private BlockFactory _blockFactory;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await SpawnNewBlock();
            ToNext();
        }

        public void ToNext()
        {
            _nextState.Enter();
        }

        private async UniTask SpawnNewBlock()
        {
            var cameraVertPos = new Vector3(0, Camera.main.transform.position.y, 0);
            var position = cameraVertPos + _blockSpawnPoint.position;

            // TODO　出現率は仮実装
            var block = _blockFactory.Generate(position, Random.Range(2, 10));
            _blockStore.Add(block);
            AudioPlayer.Instance.PlaySE(_config.OnSpawnSE);
            await block.OnSpwned();
        }
    }
}
