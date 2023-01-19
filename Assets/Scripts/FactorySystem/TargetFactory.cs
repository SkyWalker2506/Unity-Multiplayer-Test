namespace FactorySystem
{
    public class TargetFactory : ResourcesPoolFactory<TargetFactory>
    {
        protected override string PoolPath => "TargetPool";
        
        public Target GetTarget(BulletData bulletData)
        {
            return GetPoolObj() as Target;
        }
    }
}