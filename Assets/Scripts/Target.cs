using System;
using CombatSystem;
using PoolSystem;

public class Target : NetworkPoolObj, IDamagable
{
    public Action<int> OnDamaged { get; set; }

    public void ApplyDamage(int damage)
    {
        Release();
    }
}