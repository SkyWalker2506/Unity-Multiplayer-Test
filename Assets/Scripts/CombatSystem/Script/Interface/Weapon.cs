using System;
using Unity.Netcode;
using UnityEngine;

namespace CombatSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private NetworkBehaviour _owner;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _weaponTip;
        private IWeaponLogic _weaponLogic;
        public Action<BulletData> OnBulletDataChanged
        {
            get => _weaponLogic.OnBulletDataChanged;
            set => _weaponLogic.OnBulletDataChanged = value;
        }

        public BulletData BulletData => _weaponLogic.CurrentBulletData;


        private void Awake()
        {
            _weaponLogic = new WeaponLogic(_owner,_bulletPrefab, new BulletData(),_weaponTip);
        }
        
        public void PreviousSize()
        {
            _weaponLogic.PreviousSize();
        }

        public void NextSize()
        {
            _weaponLogic.NextSize();
        }

        public void PreviousColor()
        {
            _weaponLogic.PreviousColor();
        }

        public void NextColor()
        {
            _weaponLogic.NextColor();
        }

        public void Attack()
        {
            _weaponLogic.Attack();
        }
    }
}