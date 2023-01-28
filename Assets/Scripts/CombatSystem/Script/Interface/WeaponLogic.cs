using System;
using FactorySystem;
using Unity.Netcode;
using UnityEngine;

namespace CombatSystem
{
    public class WeaponLogic : IWeaponLogic
    {
        public IBulletFactory BulletFactory { get; }
        public BulletData CurrentBulletData => _currentBulletData;
        public Transform WeaponTip { get; }
        private int _bulletSizeCount => Enum.GetValues(typeof(BulletSize)).Length;
        private int _bulletColorCount => Enum.GetValues(typeof(BulletColor)).Length;
        BulletData _currentBulletData;

        public WeaponLogic(IBulletFactory bulletFactory, BulletData bulletData, Transform weaponTip)
        {
            BulletFactory = bulletFactory;
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
            AttackServerRpc();
        }
        
        [ServerRpc]
        public void AttackServerRpc()
        {
            BulletFactory.CreateBullet(CurrentBulletData, WeaponTip.position, WeaponTip.rotation);
        }
    }
}