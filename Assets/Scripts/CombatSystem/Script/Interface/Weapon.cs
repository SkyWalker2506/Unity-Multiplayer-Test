using FactorySystem;
using Unity.Netcode;
using UnityEngine;

namespace CombatSystem
{
    public class Weapon : NetworkBehaviour
    {
        [SerializeField] private Transform _weaponTip;
        private IWeaponLogic _weaponLogic;
        private void Awake()
        {
            _weaponLogic = new WeaponLogic(BulletFactory.Instance, new BulletData(),_weaponTip);
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
            if (IsHost)
            {
                _weaponLogic.Attack();
            }
            else
            {
                
            }
        }
    }
}