using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Blocks;
using MT.State;

namespace MT.PlayScreen
{
    public class BlockSpawnState : MonoBehaviour, IState
    {
        [SerializeField] private Transform _blockSpawnPoint;
        [SerializeField] private Transform _blocksParent;
        [SerializeField] private BlockGenerator _blockGenerator;
        [SerializeField] private GameObject _nextStateObject;

        public Block SpawnedBlock { get; private set; }

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            SpawnNewBlock();
            ToNext();
        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }

        [ContextMenu("spawn")]
        private void SpawnNewBlock()
        {
            var cameraVertPos = new Vector3(0, Camera.main.transform.position.y, 0);
            var position = cameraVertPos + _blockSpawnPoint.position;
            var rotation = Quaternion.identity;
            var block = _blockGenerator.RandomGenerate(position, rotation);
            block.OnSpwned();
            block.transform.SetParent(_blocksParent);
            SpawnedBlock = block;
        }
    }
}
