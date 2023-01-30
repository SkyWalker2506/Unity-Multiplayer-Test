using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class NetworkSpawnLogic : ISpawnLogic
{
    private readonly Transform _spawnerTransform;
    private readonly INetworkSpawn _spawnPrefab;
    private readonly SpawnData _spawnData;
    private List<INetworkSpawn> _spawnedObjects;

    public NetworkSpawnLogic(Transform spawnerTransform, INetworkSpawn spawnPrefab, SpawnData spawnData)
    {
        _spawnerTransform = spawnerTransform;
        _spawnPrefab = spawnPrefab;
        _spawnPrefab = spawnPrefab;
        _spawnData = spawnData;
    }

    public void Initialize()
    {
        _spawnedObjects = new List<INetworkSpawn>();
        for (int i = 0; i < _spawnData.MaxSpawnCount; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        INetworkSpawn spawnObj = Object.Instantiate((MonoBehaviour)_spawnPrefab).GetComponent<INetworkSpawn>();
        spawnObj.Transform.position = GetRandomPosition();
        spawnObj.NetworkObj.Spawn();
        _spawnedObjects.Add(spawnObj);
        spawnObj.OnDespawned += ()=> OnDespawn(spawnObj);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 spawnPos = Vector3.zero;
        
        for (int i = 0; i < _spawnData.MaxTry; i++)
        {
            spawnPos = _spawnerTransform.position + new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f)) * _spawnData.SpawnArea;
            bool isDistanceEnough = true;
            for (int j = 0; j < _spawnedObjects.Count; j++)
            {
                var distance = Vector3.Distance(spawnPos, _spawnedObjects[j].Transform.position);
                Debug.Log(distance);
                isDistanceEnough &= distance > _spawnData.MinSpawnDistance;
            }

            if (isDistanceEnough)
            {
                Debug.Log($"Try: {i+1}");
                return spawnPos;
            }
        }
        Debug.Log("Max Try");
        return spawnPos;
    }

    void OnDespawn(INetworkSpawn networkSpawn)
    {
        _spawnedObjects.Remove(networkSpawn);
        networkSpawn.OnDespawned -= ()=> OnDespawn(networkSpawn);

        if (_spawnData.MaxSpawnCount > _spawnedObjects.Count)
        {
            SpawnObject();
        }
    }
}