using System;
using PoolSystem;
using UnityEngine;

namespace FactorySystem
{
    public abstract class ResourcesPoolFactory<T> : IPoolFactory where T : new() 
    {
        public static T Instance => _lazy.Value;
        protected abstract string PoolPath { get; }
        private static readonly Lazy<T> _lazy = new Lazy<T>(() => new T());
    

        IPool _poolInstance;
        private IPool _pool
        {
            get
            {
                if (_poolInstance == null)
                {
                    _poolInstance = Resources.Load<Pool>(PoolPath);
                    _poolInstance.Initialize();
                }

                return _poolInstance;
            }
        }


        public IPoolObj GetPoolObj()
        {
            return _pool.Get();
        }

    }

    public interface IPoolFactory
    {
        IPoolObj GetPoolObj();
    }
}