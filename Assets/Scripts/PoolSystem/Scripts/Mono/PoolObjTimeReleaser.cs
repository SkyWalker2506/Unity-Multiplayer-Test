using System;
using UnityEngine;

namespace PoolSystem
{
    public class PoolObjTimeReleaser : MonoBehaviour, IPoolObj
    {
        public Action<IPoolObj> OnRelease { get; set; }
        public Transform Transform => transform;

        public IPool Pool { get; set; }
        [SerializeField] float releaseTime;

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        public void Initialize()
        {
            Invoke(nameof(Release), releaseTime);
        }

        public void Release()
        {
            OnRelease?.Invoke(this);
            Pool.Return(this);
        }
    }
}