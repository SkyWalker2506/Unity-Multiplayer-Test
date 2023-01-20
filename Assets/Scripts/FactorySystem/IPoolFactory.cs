using PoolSystem;

namespace FactorySystem
{
    public interface IPoolFactory
    {
        IPoolObj GetPoolObj();
    }
}