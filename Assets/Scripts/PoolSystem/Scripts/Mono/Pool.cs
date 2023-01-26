using UnityEngine;

namespace PoolSystem
{
    public class Pool : MonoBehaviour, IPool
    {
        [SerializeField] private GameObject _poolObjPrefab;
        [SerializeField] private int _firstCreatedAmount = 100;
        [SerializeField] private int _batchAmount = 25;

        protected IPoolLogic _poolLogic;

        public void Initialize()
        {
            _poolLogic = new PoolLogic(this, _poolObjPrefab, _batchAmount);
            CreateBatch(_firstCreatedAmount);
        }

        public virtual void CreateBatch(int amount)
        {
            _poolLogic.CreateBatch(amount);
        }

        public IPoolObj Get()
        {
            return _poolLogic.Get();
        }

        public void Return(IPoolObj poolObj)
        {
            _poolLogic.Return(poolObj);
        }

        public void OnGettingObject(IPoolObj poolObj)
        {
            _poolLogic.OnGettingObject(poolObj);
        }

        public void OnReturningObject(IPoolObj poolObj)
        {
            _poolLogic.OnReturningObject(poolObj);
        }
    }
}