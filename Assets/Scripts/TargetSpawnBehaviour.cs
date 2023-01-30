using UnityEngine;

public class TargetSpawnBehaviour : SpawnBehaviour
{
    [SerializeField] private Target _target;

    protected override INetworkSpawn NetworkSpawn()
    {
        return _target;
    }
}