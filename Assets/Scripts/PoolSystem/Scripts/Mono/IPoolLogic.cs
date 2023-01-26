namespace PoolSystem
{
    public interface IPoolLogic
    {
        void CreateBatch(int amount);
        IPoolObj Get();
        void OnReturningObject(IPoolObj poolObj);
        void OnGettingObject(IPoolObj poolObj);
        void Return(IPoolObj poolObj);
    }
}