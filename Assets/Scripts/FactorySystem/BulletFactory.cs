namespace FactorySystem
{
    public class BulletFactory : ResourcesPoolFactory<BulletFactory>
    {
        protected override string PoolPath => "BulletPool";
        
        public Bullet GetBullet(BulletData bulletData)
        {
            Bullet bullet = GetPoolObj() as Bullet;
            bullet.SetBullet(bulletData);
            return bullet;
        }
    }
    
    public class TargetFactory : ResourcesPoolFactory<TargetFactory>
    {
        protected override string PoolPath => "TargetPool";
        
        public Target GetTarget(BulletData bulletData)
        {
            return GetPoolObj() as Target;
        }
    }
}
