using System;
using Game.MovementSystem;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private PlayerInputActions _playerInputActions;
    private MovementController _movementController;
    private Vector3 _moveVector=Vector3.forward;
    
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _movementController = new MovementController(transform);
    }

    private void FixedUpdate()
    {
        _moveVector = _playerInputActions.Player.Movement.ReadValue<Vector3>();
        Debug.Log(_moveVector);
        if (_moveVector != Vector3.zero)
        {
            Move(_moveVector);
        }
    }

    private void Move(Vector3 moveVector)
    {
        _movementController.Move(moveVector*_playerData.MovementSpeed*Time.deltaTime);
    }
}

[Serializable]
public struct PlayerData
{
    public float MovementSpeed;
}