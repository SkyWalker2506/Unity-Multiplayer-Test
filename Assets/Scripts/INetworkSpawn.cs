using System;
using Unity.Netcode;
using UnityEngine;

public interface INetworkSpawn
{
    Transform Transform { get; }
    NetworkObject NetworkObj { get; }
    Action OnSpawned { get; }
    Action OnDespawned { get; set; }
}