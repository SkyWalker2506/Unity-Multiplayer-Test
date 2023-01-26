using System.Collections.Generic;
using UnityEngine;

namespace PoolSystem
{
    public sealed class PoolLogic : IPoolLogic
    {
        private List<IPoolObj> _availableObjects { get; } 
        private readonly Pool _pool;
        private GameObject _poolObjPrefab;
        private readonly int _batchAmount;

        public PoolLogic(Pool pool, GameObject poolObjPrefab, int batchAmount)
        {
            _pool = pool;
            _poolObjPrefab = poolObjPrefab;
            _batchAmount = batchAmount;
            _availableObjects = new  List<IPoolObj>();
        }

        public void CreateBatch(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                IPoolObj poolObj = Object.Instantiate(_poolObjPrefab).GetComponent<IPoolObj>();
                poolObj.Initialize(_pool);   
                Return(poolObj);
            }
        }
        
        public IPoolObj Get()
        {
            if (_availableObjects.Count == 0)
            {
                CreateBatch(_batchAmount);
            }
            IPoolObj poolObj = _availableObjects[^1];
            _availableObjects.Remove(poolObj);
            if (poolObj == null)
            {
                return Get();
            }
            OnGettingObject(poolObj);
            return poolObj;
        }

        public void OnGettingObject(IPoolObj poolObj)
        {
            Debug.Log(poolObj);
            if (poolObj != null)
            {
                GameObject obj = ((MonoBehaviour)poolObj).gameObject;
                obj.SetActive(true);
            }
        }

        public void Return(IPoolObj poolObj)
        {
            OnReturningObject(poolObj);
        }

        public void OnReturningObject(IPoolObj poolObj)
        {
            poolObj.OnRelease?.Invoke(poolObj);
            GameObject obj = ((MonoBehaviour)poolObj).gameObject;
            obj.SetActive(false);
            _availableObjects.Add(poolObj);
        }
    }
}