namespace FactorySystem
{
    public class TargetFactory : ResourcesPoolFactory<TargetFactory>
    {
        protected override string PoolPath => "TargetPool";
    }
}