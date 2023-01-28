using UnityEngine;

namespace FactorySystem
{
    public interface IBulletFactory
    {
        void CreateBullet(BulletData bulletData,Vector3 position, Quaternion rotation);
    }
}