using Unity.Netcode;

namespace PoolSystem
{
    public class NetworkPool : Pool
    {
        public override void CreateBatch(int amount)
        {
            CreateBatchServerRpc(amount);
        }

        [ServerRpc]
        void CreateBatchServerRpc(int amount)
        {
            _poolLogic.CreateBatch(amount);
        }
    }
}