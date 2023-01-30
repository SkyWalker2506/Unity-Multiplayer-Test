using UnityEngine;

namespace CombatSystem
{
    public interface IWeaponLogic : ICanAttack
    {
        BulletData CurrentBulletData { get; }
        Transform WeaponTip{ get; }
        void PreviousSize();
        void NextSize();
        void PreviousColor();
        void NextColor();
    }
}