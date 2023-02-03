using System;
using UnityEngine;

namespace CombatSystem
{
    public interface IWeaponLogic : ICanAttack
    {
        BulletData CurrentBulletData { get; }
        Action<BulletData> OnBulletDataChanged { get; set; }
        Transform WeaponTip{ get; }
        void PreviousSize();
        void NextSize();
        void PreviousColor();
        void NextColor();
    }
}