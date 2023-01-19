using UnityEngine;

namespace PoolSystem
{
    public class PoolObjTimeReleaser : PoolObj
    {
        [SerializeField] float releaseTime;

        private void OnEnable()
        {
            Invoke(nameof(Release), releaseTime);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
    }
}