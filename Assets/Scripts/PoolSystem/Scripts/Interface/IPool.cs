using System.Collections.Generic;

namespace PoolSystem
{
    public interface IPool
    {
        Stack<IPoolObj> AvailableObjects { get; set; }
        void Initialize();
        void CreateBatch(int amounts);
        IPoolObj Get();
        void Return(IPoolObj poolObj);
        void OnGettingObject(IPoolObj obj);
        void OnReturningObject(IPoolObj obj);
    }
}
