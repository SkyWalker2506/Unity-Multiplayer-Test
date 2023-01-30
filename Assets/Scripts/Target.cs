using System;
using CombatSystem;
using Unity.Netcode;
using UnityEngine;

public class Target : NetworkBehaviour, INetworkSpawn, IDamagable
{
    public Transform Transform => transform;
    public NetworkObject NetworkObj => NetworkObject;
    public Action OnSpawned { get; }
    public Action OnDespawned { get; set; }
    public Action<int> OnDamaged { get; set; }

    public void ApplyDamage(int damage)
    {
        if (IsSpawned)
        {
            NetworkObj.Despawn();
        }
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        OnSpawned?.Invoke();
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        OnDespawned?.Invoke();
    }
}