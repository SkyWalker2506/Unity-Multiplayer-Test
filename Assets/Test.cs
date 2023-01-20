using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Test : NetworkBehaviour
{
    [SerializeField] private NetworkObject _prefab;
    [SerializeField] private int _count = 10;

    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += Create;
    }

    private void OnDisable()
    {
        NetworkManager.Singleton.OnServerStarted -= Create;
    }

    private void Create()
    {
        if (IsHost)
        {
            for (int i = 0; i < _count; i++)
            {
                var c = Instantiate(_prefab);
                c.transform.position = new Vector3(i, 0, i);
                c.Spawn(true);
            }
        }
    }
}
