using System;
using FactorySystem;
using Unity.Netcode;
using UnityEngine;

public class SpawnBehaviour : NetworkBehaviour
{
    [SerializeField] private SpawnData _spawnData;
    private ISpawnLogic _spawnLogic;

    private void OnEnable()
    {
        NetworkManager.OnServerStarted += Spawn;
    }

    private void OnDisable()
    {
        NetworkManager.OnServerStarted -= Spawn;
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