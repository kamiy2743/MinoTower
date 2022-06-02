using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;


namespace MT.PlayScreen
{
    public class BlockSpawnState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private Transform _blockSpawnPoint;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private BlockGenerator _blockGenerator;
        [SerializeField] private SEType _onSpawnSE;
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
            var rotation = Quaternion.identity;
            var block = _blockGenerator.RandomGenerate(position, rotation);
            _blockStore.Add(block);
            AudioManager.Instance.PlaySE(_onSpawnSE);
            await block.OnSpwned();
        }
    }
}
