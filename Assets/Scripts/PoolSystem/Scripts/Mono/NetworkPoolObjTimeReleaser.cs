using Unity.Netcode;

namespace PoolSystem
{
    public class NetworkPoolObjTimeReleaser : PoolObjTimeReleaser , INetworkPoolObj
    {
        public NetworkObject NetworkObject { get; private set; }
        
        public override void Initialize(IPool pool)
        {
            base.Initialize(pool);
            NetworkObject = Transform.GetComponent<NetworkObject>();
            NetworkObject.Spawn(true);
        }
    }
}