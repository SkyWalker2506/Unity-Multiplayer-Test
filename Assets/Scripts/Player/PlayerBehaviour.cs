using System;
using Game.MovementSystem;
using Unity.Netcode;
using UnityEngine;

public class PlayerBehaviour : NetworkBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private PlayerInputActions _playerInputActions;
    private IMovementLogic _movementLogic;
    private ILookLogic _lookLogic;
    private Vector3 _moveVector;
    private Vector2 _lookVector;
    
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _movementLogic = new TransformMovement(transform,_playerData.MovementSpeed);
        _lookLogic = new TransformLook(transform, _playerData.LookCamera, _playerData.LookSensitivity, _playerData.LookAngle);
    }

    private void Start()
    {
        _playerData.LookCamera.gameObject.SetActive(IsOwner);
    }

    private void FixedUpdate()
    {
        if (IsOwner)
        {
            OnMove();
            OnLook();
        }
    }

    private void OnMove()
    {
        _moveVector = _playerInputActions.Player.Movement.ReadValue<Vector3>();
        Debug.Log(_moveVector);
        if (_moveVector != Vector3.zero)
        {
            _movementLogic.Move(_moveVector);
        }
    }
    
    private void OnLook()
    {
        _lookVector = _playerInputActions.Player.Look.ReadValue<Vector2>();
        Debug.Log(_lookVector);
        if (_lookVector != Vector2.zero)
        {
            _lookLogic.Look(_lookVector);
        }
    }
}