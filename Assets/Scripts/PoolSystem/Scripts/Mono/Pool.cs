using System;
using System.Collections.Generic;
using UnityEngine;

namespace PoolSystem
{
    
    public class Pool : MonoBehaviour, IPool
    {
        [SerializeField] private GameObject _poolObjPrefab;
        [SerializeField] private int _firstCreatedAmount = 100;
        [SerializeField] private int _batchAmount = 25;

        public Stack<IPoolObj> AvailableObjects { get; set; }

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            AvailableObjects = new Stack<IPoolObj>();
            if (_poolObjPrefab != null)
            {
                CreateBatch(_firstCreatedAmount);
            }
        }

        public void CreateBatch(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                IPoolObj poolObj = Instantiate(_poolObjPrefab).GetComponent<IPoolObj>();
                GameObject go = ((MonoBehaviour)poolObj).gameObject;
                go.SetActive(false);
                go.name = _poolObjPrefab.name;
                poolObj.Initialize(this);
                AvailableObjects.Push(poolObj);
            }
        }

        public IPoolObj Get()
        {
            if (AvailableObjects.Count == 0)
            {
                CreateBatch(_batchAmount);
            }
            IPoolObj obj = AvailableObjects.Pop();
            OnGettingObject(obj);
            return obj;
        }

        public void SetPrefab(GameObject poolObj)
        {
            _poolObjPrefab = poolObj;
        }

        public void Return(IPoolObj poolObj)
        {
            AvailableObjects.Push(poolObj);
            OnReturningObject(poolObj);
        }

        public void OnGettingObject(IPoolObj poolObj)
        {
            GameObject obj = ((MonoBehaviour)poolObj).gameObject;
            obj.SetActive(true);
        }

        public void OnReturningObject(IPoolObj poolObj)
        {
            GameObject obj = ((MonoBehaviour)poolObj).gameObject;
            obj.SetActive(false);
        }
    }
}