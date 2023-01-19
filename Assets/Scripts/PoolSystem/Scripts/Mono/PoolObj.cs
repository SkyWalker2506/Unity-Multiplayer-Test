using System;
using UnityEngine;

namespace PoolSystem
{
    public class PoolObj : MonoBehaviour, IPoolObj
    {
        public Action<IPoolObj> OnRelease { get; set; }
        public Transform Transform => transform;

        public IPool Pool { get; set; }

        public virtual void Initialize(IPool pool)
        {
            Pool = pool;
        }

        public void Release()
        {
            OnRelease?.Invoke(this);
            Pool.Return(this);
        }
    }
}