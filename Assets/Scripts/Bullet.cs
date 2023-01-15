using System;
using CombatSystem;
using PoolSystem;
using UnityEngine;

public class Bullet : PoolObj , IDamager
{
    [SerializeField] private Material _bulletMaterial;
    [SerializeField] private float _smallBulletSize = .5f;
    [SerializeField] private float _standardBulletSize = 1f;
    [SerializeField] private float _largeBulletSize = 2;
    public int Damage { get; }
    public Action<int> OnDamage { get; set; }


    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable;
        if (other.TryGetComponent<IDamagable>(out damagable))
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
                _bulletMaterial.color = Color.blue;
                break;
            case BulletColor.Red:
                _bulletMaterial.color = Color.red;
                break;
            case BulletColor.Green:
                _bulletMaterial.color = Color.green;
                break;
        }
    }

    public void ApplyDamage(IDamagable damagable)
    {
        damagable.ApplyDamage(Damage);
        OnDamage?.Invoke(Damage);
        Release();
    }
}