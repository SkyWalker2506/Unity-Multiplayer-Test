using System;
using UnityEngine;

public class BulletFactory 
{
    public static BulletFactory Instance => lazy.Value;
    private static readonly Lazy<BulletFactory> lazy = new Lazy<BulletFactory>(() => new BulletFactory());

    private BulletPool _bulletPool;
    
    private BulletPool _bulletPoolInstance
    {
        get
        {
            if (_bulletPool==null)
            {
                _bulletPool = Resources.Load<BulletPool>("BulletPool");
                _bulletPool.Initialize();
            }

            return _bulletPool;
        }
    }


    public Bullet GetBullet(BulletData bulletData)
    {
        Debug.Log(_bulletPoolInstance);
        Bullet bullet = _bulletPoolInstance.Get() as Bullet;
        bullet.SetBullet(bulletData);
        return bullet;
    }
}