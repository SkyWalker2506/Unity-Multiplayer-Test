using System.Collections.Generic;
using FactorySystem;
using PoolSystem;
using UnityEngine;

public class SpawnLogic : ISpawnLogic
{
    private readonly Transform _spawnerTransform;
    private readonly IPoolFactory _poolFactory;
    private readonly SpawnData _spawnData;
    private List<IPoolObj> _spawnedObjects;

    public SpawnLogic(Transform spawnerTransform, IPoolFactory PoolFactory, SpawnData spawnData)
    {
        _spawnerTransform = spawnerTransform;
        _poolFactory = PoolFactory;
        _spawnData = spawnData;
    }

    public void Initialize()
    {
        _spawnedObjects = new List<IPoolObj>();
        for (int i = 0; i < _spawnData.MaxSpawnCount; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        IPoolObj spawnObj = _poolFactory.GetPoolObj();
        spawnObj.Transform.position = GetRandomPosition();
        spawnObj.OnRelease += OnSpawnReleased;
        _spawnedObjects.Add(spawnObj);
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

    void OnSpawnReleased(IPoolObj poolObj)
    {
        _spawnedObjects.Remove(poolObj);
        poolObj.OnRelease -= OnSpawnReleased;
        if (_spawnData.MaxSpawnCount > _spawnedObjects.Count)
        {
            SpawnObject();
        }
    }
}