using System;
using CombatSystem;
using Game.MovementSystem;
using PoolSystem;
using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour , IDamager
{
    public int Damage { get; }
    public Action<int> OnDamage { get; set; }
    
    [SerializeField] private float _bulletSpeed = 5;
    [SerializeField] private MeshRenderer _bulletRenderer;
    [SerializeField] private float _smallBulletSize = .5f;
    [SerializeField] private float _standardBulletSize = 1f;
    [SerializeField] private float _largeBulletSize = 2;
    
    private IMovementLogic _movementLogic;

    private void Awake()
    {
        _movementLogic = new TransformMovement(transform, _bulletSpeed);
    }

    private void Update()
    {
        _movementLogic.Move(transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            ApplyDamage(damagable);
        }
    }

    public void SetBullet(BulletData bulletData)
    {
        SetBulletSize(bulletData.Size);
        SetBulletColor(bulletData.Color);
    }

    void SetBulletSize(BulletSize size)
    {
        switch (size)
        {
            case BulletSize.Small:
                transform.localScale = Vector3.one * _smallBulletSize;
                break;
            case BulletSize.Standard:
                transform.localScale = Vector3.one * _standardBulletSize;
                break;
            case BulletSize.Large:
                transform.localScale = Vector3.one * _largeBulletSize;
                break;
        }
    }

    void SetBulletColor(BulletColor color)
    {
        switch (color)
        {
            case BulletColor.Blue:
                _bulletRenderer.material.color = Color.blue;
                break;
            case BulletColor.Red:
                _bulletRenderer.material.color = Color.red;
                break;
            case BulletColor.Green:
                _bulletRenderer.material.color = Color.green;
                break;
        }
    }

    public void ApplyDamage(IDamagable damagable)
    {
        damagable.ApplyDamage(Damage);
        OnDamage?.Invoke(Damage);
    }
}