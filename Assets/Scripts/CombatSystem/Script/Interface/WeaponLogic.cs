using System;
using Unity.Netcode;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CombatSystem
{
    public class WeaponLogic : IWeaponLogic
    {
        private NetworkBehaviour _owner;
        private Bullet _bulletPrefab { get; }
        public BulletData CurrentBulletData => _currentBulletData;
        public Transform WeaponTip { get; }
        private int _bulletSizeCount => Enum.GetValues(typeof(BulletSize)).Length;
        private int _bulletColorCount => Enum.GetValues(typeof(BulletColor)).Length;
        BulletData _currentBulletData;

        public WeaponLogic(NetworkBehaviour owner, Bullet bulletPrefab, BulletData bulletData, Transform weaponTip)
        {
            _owner = owner;
            _bulletPrefab = bulletPrefab;
            _currentBulletData = bulletData;
            WeaponTip = weaponTip;
        }

        public void PreviousSize()
        {
            _currentBulletData.Size = (BulletSize)(((int)_currentBulletData.Size -1 + _bulletSizeCount) % _bulletSizeCount);
            Debug.Log(_currentBulletData.Size);
        }

        public void NextSize()
        {
            _currentBulletData.Size  = (BulletSize)(((int)_currentBulletData.Size + 1) % _bulletSizeCount);
            Debug.Log(_currentBulletData.Size);
        }

        public void PreviousColor()
        {
            _currentBulletData.Color = (BulletColor)(((int)_currentBulletData.Color - 1 + _bulletColorCount) % _bulletColorCount);
            Debug.Log(_currentBulletData.Color);
        }

        public void NextColor()
        {
            _currentBulletData.Color = (BulletColor)(((int)_currentBulletData.Color + 1) % _bulletColorCount);
            Debug.Log(_currentBulletData.Color);
        }

        public void Attack()
        {
                CreateBulletServerRpc((int)CurrentBulletData.Color, (int)CurrentBulletData.Size,WeaponTip.position,WeaponTip.rotation);
        }
        
      //  [ServerRpc(RequireOwnership = false)]
        private void CreateBulletServerRpc(int colorIndex, int sizeIndex, Vector3 position, Quaternion rotation)
        {
            Debug.Log(colorIndex+ "  color index");
            Debug.Log(sizeIndex+ "  size index");
          //  if (!NetworkManager.Singleton.IsHost) return;
            Bullet bullet = Object.Instantiate(_bulletPrefab);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.NetworkObject.Spawn();
            SetBulletClientRpc(bullet.NetworkObjectId, colorIndex, sizeIndex);
        }
        
        [ClientRpc]
        private void SetBulletClientRpc(ulong id, int colorIndex, int sizeIndex)
        {
            Debug.Log("SetBulletClientRpc");
            NetworkManager.Singleton.SpawnManager.SpawnedObjects[id].GetComponent<Bullet>().SetBullet(new BulletData((BulletColor)colorIndex, (BulletSize)sizeIndex));
        }
    }
}