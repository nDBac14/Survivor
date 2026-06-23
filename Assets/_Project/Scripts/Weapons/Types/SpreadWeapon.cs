using UnityEngine;

public class SpreadWeapon : WeaponBase
{
    [SerializeField] private float spreadAngle = 30f;  // tổng góc xòe

    protected override void Attack()
    {
        Transform target = EnemyRegistry.GetNearest(transform.position, data.range);
        if (target == null) return;

        Vector2 baseDir = ((Vector2)target.position - (Vector2)transform.position).normalized;
        int count = data.CountAt(level);

        for (int i = 0; i < count; i++)
        {
            float t = count == 1 ? 0.5f : (float)i / (count - 1);            // 0..1
            float angle = Mathf.Lerp(-spreadAngle / 2f, spreadAngle / 2f, t);
            FireProjectile(Rotate(baseDir, angle));
        }
    }

    private Vector2 Rotate(Vector2 v, float deg)
    {
        float r = deg * Mathf.Deg2Rad, c = Mathf.Cos(r), s = Mathf.Sin(r);
        return new Vector2(v.x * c - v.y * s, v.x * s + v.y * c);
    }
}