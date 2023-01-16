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
            Invoke(nameof(Release), releaseTime);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        public void Release()
        {
            Pool.Return(this);
        }
    }
}