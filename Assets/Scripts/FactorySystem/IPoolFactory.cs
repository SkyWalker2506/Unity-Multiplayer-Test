using PoolSystem;

namespace FactorySystem
{
    public interface IPoolFactory
    {
        IPool Pool { get; }
        IPoolObj GetPoolObj();
    }
}