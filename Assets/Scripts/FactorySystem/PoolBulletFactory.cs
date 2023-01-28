using System;
using UnityEngine;

namespace FactorySystem
{
    public class PoolBulletFactory : ResourcesPoolFactory<PoolBulletFactory>, IBulletFactory 
    {
        protected override string PoolPath => "BulletPool";

        public Bullet GetBullet(BulletData bulletData)
        {
            Bullet bullet = GetPoolObj() as Bullet;
            bullet.SetBullet(bulletData);
            return bullet;
        }

        public void CreateBullet(BulletData bulletData, Vector3 position, Quaternion rotation)
        {
            throw new NotImplementedException();
        }
    }
}
