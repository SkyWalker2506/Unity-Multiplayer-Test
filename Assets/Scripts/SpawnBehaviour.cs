using FactorySystem;
using Unity.Netcode;
using UnityEngine;

public class SpawnBehaviour : NetworkBehaviour
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

    private void Spawn()
    {
        if (IsHost)
        {
            _spawnLogic = new SpawnLogic(transform, TargetFactory.Instance, _spawnData);
            _spawnLogic.Initialize();
        }
    }
}