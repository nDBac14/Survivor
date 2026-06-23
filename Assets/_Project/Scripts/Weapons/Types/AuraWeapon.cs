using UnityEngine;

public class AuraWeapon : WeaponBase
{
    protected override void Attack()
    {
        float dmg = data.DamageAt(level);
        float rangeSqr = data.range * data.range;
        var enemies = EnemyRegistry.All;

        // duyệt ngược để an toàn khi quái chết (bị gỡ khỏi danh sách giữa chừng)
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            var e = enemies[i];
            if (((Vector2)e.position - (Vector2)transform.position).sqrMagnitude <= rangeSqr)
            {
                if (e.TryGetComponent<Health>(out var hp))
                    hp.TakeDamage(dmg);
            }
        }
    }
}