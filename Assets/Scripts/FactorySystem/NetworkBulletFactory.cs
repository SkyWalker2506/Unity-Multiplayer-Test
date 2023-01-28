using Unity.Netcode;
using UnityEngine;

namespace FactorySystem
{
    public class NetworkBulletFactory : NetworkBehaviour, IBulletFactory
    {
        public static NetworkBulletFactory Instance;
        [SerializeField] private Bullet _bulletPrefab;

        private void Awake()
        {
            Instance = this;
        }

        public void CreateBullet(BulletData bulletData, Vector3 position, Quaternion rotation)
        {
            CreateBulletServerRpc((int)bulletData.Color, (int)bulletData.Size,position,rotation);
        }

        [ServerRpc(RequireOwnership = false)]
        private void CreateBulletServerRpc(int colorIndex, int sizeIndex, Vector3 position, Quaternion rotation)
        {
            Debug.Log(colorIndex+ "  color index");
            Debug.Log(sizeIndex+ "  size index");
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.NetworkObject.Spawn();
            SetBulletClientRpc(bullet.NetworkObjectId, colorIndex, sizeIndex);
        }
        
        [ClientRpc]
        private void SetBulletClientRpc(ulong id, int colorIndex, int sizeIndex)
        {
            Debug.Log("SetBulletClientRpc");
            NetworkManager.SpawnManager.SpawnedObjects[id].GetComponent<Bullet>().SetBullet(new BulletData((BulletColor)colorIndex, (BulletSize)sizeIndex));
        }
    }
}