using UnityEngine;

public class KunaiWeapon : WeaponBase
{
    protected override void Attack()
    {
        Transform target = EnemyRegistry.GetNearest(transform.position, data.range);
        if (target == null) return;

        Vector2 dir = (Vector2)target.position - (Vector2)transform.position;
        FireProjectile(dir);
    }
}