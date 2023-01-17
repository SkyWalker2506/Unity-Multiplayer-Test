using System;
using CombatSystem;
using PoolSystem;

public class Target : PoolObj, IDamagable
{
    public Action<int> OnDamaged { get; set; }

    public override void Initialize()
    {
        
    }

    public void ApplyDamage(int damage)
    {
        Release();
    }
}