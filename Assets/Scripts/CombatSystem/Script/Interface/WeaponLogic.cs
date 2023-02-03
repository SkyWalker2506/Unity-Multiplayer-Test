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
        public Action<BulletData> OnBulletDataChanged
        {
            get => onBulletDataChanged;
            set => onBulletDataChanged = value;
        }

        public Transform WeaponTip { get; }
        private int _bulletSizeCount => Enum.GetValues(typeof(BulletSize)).Length;
        private int _bulletColorCount => Enum.GetValues(typeof(BulletColor)).Length;
        BulletData _currentBulletData;
        private Action<BulletData> onBulletDataChanged;
        
        
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
            onBulletDataChanged?.Invoke(_currentBulletData);
        }

        public void NextSize()
        {
            _currentBulletData.Size  = (BulletSize)(((int)_currentBulletData.Size + 1) % _bulletSizeCount);
            Debug.Log(_currentBulletData.Size);
            onBulletDataChanged?.Invoke(_currentBulletData);
        }

        public void PreviousColor()
        {
            _currentBulletData.Color = (BulletColor)(((int)_currentBulletData.Color - 1 + _bulletColorCount) % _bulletColorCount);
            Debug.Log(_currentBulletData.Color);
            onBulletDataChanged?.Invoke(_currentBulletData);
        }

        public void NextColor()
        {
            _currentBulletData.Color = (BulletColor)(((int)_currentBulletData.Color + 1) % _bulletColorCount);
            Debug.Log(_currentBulletData.Color);
            onBulletDataChanged?.Invoke(_currentBulletData);
        }

        public void Attack()
        {
            Bullet bullet = Object.Instantiate(_bulletPrefab);
            bullet.transform.position = WeaponTip.position;
            bullet.transform.rotation = WeaponTip.rotation;
            bullet.NetworkObject.Spawn();
            bullet.SetBullet(CurrentBulletData);
        }
    }
}