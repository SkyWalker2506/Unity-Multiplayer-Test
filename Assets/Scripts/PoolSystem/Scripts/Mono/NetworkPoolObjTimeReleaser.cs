using FactorySystem;
using Unity.Netcode;
using UnityEngine;

namespace PoolSystem
{
    public class NetworkPoolObjTimeReleaser : PoolObjTimeReleaser , INetworkPoolObj
    {
        public NetworkObject NetworkObject { get; private set; }
        
        public override void Initialize(IPool pool)
        {
            InitializeServerRpc();
            ReleaseServerRpc();
        }
        
        [ServerRpc]
        private void InitializeServerRpc()
        {
            Debug.Log("Initialized", gameObject);
            Pool = PoolBulletFactory.Instance.Pool;
            NetworkObject = Transform.GetComponent<NetworkObject>();
            NetworkObject.Spawn(true);
        }
        
        public override void Release()
        {
            ReleaseServerRpc();
        }
        
        [ServerRpc]
        private void ReleaseServerRpc()
        {
            Debug.Log("ReleaseServerRpc", gameObject);
            Pool.Return(this);
            NetworkObject.Despawn(false);
        }
    }
}