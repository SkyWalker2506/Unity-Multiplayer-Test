using Unity.Netcode;

namespace PoolSystem
{
    public interface INetworkPoolObj : IPoolObj
    {
        NetworkObject NetworkObject{ get; }
    }
}