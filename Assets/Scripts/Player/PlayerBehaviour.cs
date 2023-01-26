using CombatSystem;
using Game.MovementSystem;
using Unity.Netcode;
using UnityEngine;

public class PlayerBehaviour : NetworkBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Weapon _weapon;
    private PlayerInputActions _playerInputActions;
    private IMovementLogic _movementLogic;
    private ILookLogic _lookLogic;
    private Vector2 _moveVector;
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

    private void Update()
    {
        if (IsOwner)
        {
            OnMove();
            OnLook();
            OnBulletChanged();
            OnFire();
        }
    }

    private void OnMove()
    {
        _moveVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
//        Debug.Log(_moveVector);
        if (_moveVector != Vector2.zero)
        {
            _movementLogic.Move(transform.right * _moveVector.x + transform.forward * _moveVector.y);
        }
    }
    
    private void OnLook()
    {
        _lookVector = _playerInputActions.Player.Look.ReadValue<Vector2>();
//        Debug.Log(_lookVector);
        if (_lookVector != Vector2.zero)
        {
            _lookLogic.Look(_lookVector);
        }
    }

    private void OnBulletChanged()
    {
        if (_playerInputActions.Player.PreviousSize.WasPressedThisFrame())
        {
            _weapon.PreviousSize();
        }
        else if (_playerInputActions.Player.NextSize.WasPressedThisFrame())
        {
            _weapon.NextSize();
        }
        else if (_playerInputActions.Player.PreviousColor.WasPressedThisFrame())
        {
            _weapon.PreviousColor();
        }
        else if (_playerInputActions.Player.NextColor.WasPressedThisFrame())
        {
            _weapon.NextColor();
        }
    }

    private void OnFire()
    {
        if (_playerInputActions.Player.Fire.WasPressedThisFrame())
        {
            _weapon.Attack();
        }
    }
    
    
}