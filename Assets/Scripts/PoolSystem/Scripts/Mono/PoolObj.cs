using UnityEngine;

namespace PoolSystem
{
    public class PoolObj : MonoBehaviour, IPoolObj
    {
        public Transform Transform => transform;

        public IPool Pool { get; set; }

        public virtual void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Release()
        {
            Pool.Return(this);
        }
    }
}