using System;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetManager : NetworkBehaviour
{
    [SerializeField] private TargetSpawnBehaviour _targetSpawnBehaviour;
    [SerializeField] private float _targetChangeTime;
    public static Action OnTargetChanged;

    private void OnEnable()
    {
        GameEventsManager.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        GameEventsManager.OnGameStarted -= OnGameStarted;
        if (!IsHost)
        {
            NetworkManager.OnServerStarted -= SendCurrentBulletDataServerRpc;
        }
    }
    
    private void OnGameStarted()
    {
        if (IsHost)
        {
            _targetSpawnBehaviour.Spawn();
            InvokeRepeating(nameof(ChangeTarget),1,_targetChangeTime);    
        }
        else
        {
            SendCurrentBulletDataServerRpc();
        }
    }

    private void ChangeTarget()
    {
        GameInfo.CurrentBullet = new BulletData((BulletColor)Random.Range(0, Enum.GetNames(typeof(BulletColor)).Length), (BulletSize)Random.Range(0, Enum.GetNames(typeof(BulletSize)).Length));
        SendCurrentBulletDataServerRpc();
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void SendCurrentBulletDataServerRpc()
    {
        SendCurrentBulletClientRpc((int)GameInfo.CurrentBullet.Color, (int)GameInfo.CurrentBullet.Size);
    }
    
    [ClientRpc]
    private void SendCurrentBulletClientRpc(int colorIndex, int sizeIndex)
    {
        GameInfo.CurrentBullet = new BulletData((BulletColor)colorIndex, (BulletSize)sizeIndex);
        OnTargetChanged?.Invoke();
    }
}