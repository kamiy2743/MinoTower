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

        public Block SpawnedBlock { get; private set; }

        [SerializeField] private GameObject _nextState;
        public IState NextState { get; private set; }
        public void Enter()
        {
            gameObject.SetActive(true);
            SpawnNewBlock();
            Exit();
        }
        public void Exit()
        {
            gameObject.SetActive(false);
            NextState.Enter();
        }

        void Awake()
        {
            NextState = _nextState.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        [ContextMenu("spawn")]
        private void SpawnNewBlock()
        {
            var position = _blockSpawnPoint.position;
            var rotation = Quaternion.identity;
            var block = _blockGenerator.RandomGenerate(position, rotation);
            block.OnSpwned();
            block.transform.SetParent(_blocksParent);
            SpawnedBlock = block;
        }
    }
}
