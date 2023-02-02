using Unity.Netcode;
using UnityEngine;

public abstract class SpawnBehaviour : NetworkBehaviour
{
    [SerializeField] private SpawnData _spawnData;
    private ISpawnLogic _spawnLogic;
    
    protected abstract INetworkSpawn NetworkSpawn();

    public void Spawn()
    {
        if (IsHost)
        {
            _spawnLogic = new NetworkSpawnLogic(transform, NetworkSpawn(), _spawnData);
            _spawnLogic.Initialize();
        }
    }
}