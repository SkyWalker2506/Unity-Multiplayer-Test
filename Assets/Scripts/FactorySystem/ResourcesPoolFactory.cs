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
    

        IPool _pool;
        public IPool Pool
        {
            get
            {
                if (_pool == null)
                {
                    _pool = Resources.Load<Pool>(PoolPath);
                    _pool.Initialize();
                }

                return _pool;
            }
        }


        public IPoolObj GetPoolObj()
        {
            return Pool.Get();
        }

    }
}