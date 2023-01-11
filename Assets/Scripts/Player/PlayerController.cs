using System;
using Game.MovementSystem;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private MovementController _movementController;

    private void Awake()
    {
        _movementController = new MovementController(transform);
    }

    public void OnMove(InputValue value)
    {
        _movementController.Move(value.Get<Vector2>()*_playerData.MovementSpeed*Time.deltaTime);
    }
}

[Serializable]
public struct PlayerData
{
    public float MovementSpeed;
}