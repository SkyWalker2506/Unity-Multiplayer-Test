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
        if (_moveVector != Vector2.zero)
        {
            _movementLogic.Move(transform.right * _moveVector.x + transform.forward * _moveVector.y);
        }
    }
    
    private void OnLook()
    {
        _lookVector = _playerInputActions.Player.Look.ReadValue<Vector2>();
        if (_lookVector != Vector2.zero)
        {
            _lookLogic.Look(_lookVector);
        }
    }

    private void OnBulletChanged()
    {
        if (_playerInputActions.Player.PreviousSize.WasPressedThisFrame())
        {
            PreviousSizeServerRpc();
        }
        else if (_playerInputActions.Player.NextSize.WasPressedThisFrame())
        {
            NextSizeServerRpc();
        }
        else if (_playerInputActions.Player.PreviousColor.WasPressedThisFrame())
        {
            PreviousColorServerRpc();
        }
        else if (_playerInputActions.Player.NextColor.WasPressedThisFrame())
        {
            NextColorServerRpc();
        }
    }

    private void OnFire()
    {
        if (_playerInputActions.Player.Fire.WasPressedThisFrame())
        {
            AttackServerRpc();
        }
    }

    [ServerRpc]
    private void AttackServerRpc()
    {
        _weapon.Attack();
    }    
    
    [ServerRpc]
    private void NextSizeServerRpc()
    {
        NextSizeClientRpc();
    }  
    
    [ServerRpc]
    private void PreviousSizeServerRpc()
    {
        PreviousSizeClientRpc();
    }  
    
    [ServerRpc]
    private void NextColorServerRpc()
    {
        NextColorClientRpc();
    }  
    
    [ServerRpc]
    private void PreviousColorServerRpc()
    {
        PreviousColorClientRpc();
    }  

    [ClientRpc]
    private void NextSizeClientRpc()
    {
        _weapon.NextSize();
        GameEventsManager.OnBulletChanged?.Invoke();
    }  
    
    [ClientRpc]
    private void PreviousSizeClientRpc()
    {
        _weapon.PreviousSize();
        GameEventsManager.OnBulletChanged?.Invoke();
    }  
    
    [ClientRpc]
    private void NextColorClientRpc()
    {
        _weapon.NextColor();
        GameEventsManager.OnBulletChanged?.Invoke();
    }  
    
    [ClientRpc]
    private void PreviousColorClientRpc()
    {
        _weapon.PreviousColor();
        GameEventsManager.OnBulletChanged?.Invoke();
    }  
    
}