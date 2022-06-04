using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT
{
    public class BlockSynchronizer : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private BlockStore _blockStore;

        private bool _isSynchronize = false;

        public void SetIsSynchronize(bool value)
        {
            _isSynchronize = value;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (!_isSynchronize) return;

            if (stream.IsWriting)
            {
                var conditions = GetBlockConditions();
                stream.SendNext(conditions);
            }
            else
            {
                var conditions = (List<BlockCondition>)stream.ReceiveNext();
                ApplyConditions(conditions);
            }
        }

        private List<BlockCondition> GetBlockConditions()
        {
            var blocks = _blockStore.Blocks();
            var consitions = new List<BlockCondition>(blocks.Length);

            foreach (var block in blocks)
            {
                var condition = new BlockCondition(block.transform.position, block.transform.rotation);
                consitions.Add(condition);
            }

            return consitions;
        }

        private void ApplyConditions(List<BlockCondition> conditions)
        {
            var blocks = _blockStore.Blocks();
            for (int i = 0; i < blocks.Length; i++)
            {
                var tf = blocks[i].transform;
                var condition = conditions[i];

                tf.position = condition.Position;
                tf.rotation = condition.Rotation;
            }
        }

        private struct BlockCondition
        {
            public Vector2 Position;
            public Quaternion Rotation;

            public BlockCondition(Vector2 position, Quaternion rotation)
            {
                Position = position;
                Rotation = rotation;
            }
        }
    }
}
