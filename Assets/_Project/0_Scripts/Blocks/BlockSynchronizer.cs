using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using MSLIMA.Serializer;

namespace MT
{
    public class BlockSynchronizer : MonoBehaviourPunCallbacks, IPunObservable, IStaticAwake
    {
        [SerializeField] private BlockStore _blockStore;

        private bool _isSynchronize = false;

        public void StaticAwake()
        {
            Serializer.RegisterCustomType<BlockCondition>((byte)'A');
        }

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
                var conditions = (BlockCondition[])stream.ReceiveNext();
                ApplyConditions(conditions);
            }
        }

        private BlockCondition[] GetBlockConditions()
        {
            var blocks = _blockStore.Blocks();
            var consitions = new List<BlockCondition>(blocks.Length);

            foreach (var block in blocks)
            {
                var condition = new BlockCondition(block.transform.position, block.transform.rotation);
                consitions.Add(condition);
            }

            return consitions.ToArray();
        }

        private void ApplyConditions(BlockCondition[] conditions)
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

        [System.Serializable]
        private struct BlockCondition
        {
            public Vector2 Position;
            public Quaternion Rotation;

            public BlockCondition(Vector2 position, Quaternion rotation)
            {
                Position = position;
                Rotation = rotation;
            }

            public static byte[] Serialize(object customObject)
            {
                BlockCondition o = (BlockCondition)customObject;
                byte[] bytes = new byte[0];

                Serializer.Serialize(o.Position, ref bytes);
                Serializer.Serialize(o.Rotation, ref bytes);

                return bytes;
            }

            public static object Deserialize(byte[] bytes)
            {
                BlockCondition o = new BlockCondition();
                int offset = 0;

                o.Position = Serializer.DeserializeVector2(bytes, ref offset);
                o.Rotation = Serializer.DeserializeQuaternion(bytes, ref offset);

                return o;
            }
        }
    }
}
