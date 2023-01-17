using UnityEngine;

namespace PoolSystem
{
    public class PoolObjTimeReleaser : MonoBehaviour, IPoolObj
    {
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
            Pool.Return(this);
        }
    }
}