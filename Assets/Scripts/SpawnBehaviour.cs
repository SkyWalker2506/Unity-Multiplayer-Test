using Unity.Netcode;
using UnityEngine;

public abstract class SpawnBehaviour : NetworkBehaviour
{
    [SerializeField] private SpawnData _spawnData;
    private ISpawnLogic _spawnLogic;
    
    private void Start()
    {
        if (NetworkManager.Singleton)
        {        
            NetworkManager.Singleton.OnServerStarted += Spawn;
        }
    }

    private void OnDisable()
    {
        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.OnServerStarted -= Spawn;
        }
    }

    protected abstract INetworkSpawn NetworkSpawn();

    private void Spawn()
    {
        if (IsHost)
        {
            _spawnLogic = new NetworkSpawnLogic(transform, NetworkSpawn(), _spawnData);
            _spawnLogic.Initialize();
        }
    }
}