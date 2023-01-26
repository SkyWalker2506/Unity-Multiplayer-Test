﻿using Unity.Netcode;

namespace PoolSystem
{
    public class NetworkPoolObj : PoolObj, INetworkPoolObj
    {
        public NetworkObject NetworkObject { get; private set; }
        
        public override void Initialize(IPool pool)
        {
            base.Initialize(pool);
            NetworkObject = Transform.GetComponent<NetworkObject>();
            NetworkObject.Spawn(true);
        }

        public override void Release()
        {
            base.Release();
            if(NetworkObject.IsSpawned)
            {
                NetworkObject.Despawn(false);
            }
        }
    }
}