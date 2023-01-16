using System;
using UnityEngine;

namespace CombatSystem
{
    public class WeaponLogic : IWeaponLogic
    {
        public BulletFactory BulletFactory { get; }
        public BulletData CurrentBulletData => _currentBulletData;
        public Transform WeaponTip { get; }
        
        private int _bulletSizeCount => Enum.GetValues(typeof(BulletSize)).Length;
        private int _bulletColorCount => Enum.GetValues(typeof(BulletColor)).Length;
        BulletData _currentBulletData;

        public WeaponLogic(BulletFactory bulletFactory, BulletData bulletData, Transform weaponTip)
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
            Transform bulletTransform= BulletFactory.GetBullet(CurrentBulletData).transform;
            bulletTransform.position = WeaponTip.position;
            bulletTransform.rotation = WeaponTip.rotation;
        }
    }
}