using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected WeaponData data;
    protected int level = 1;
    private float cooldownTimer;
    private PlayerStats stats;

    public WeaponData Data => data;
    public int Level => level;
    public bool IsMaxLevel => level >= data.MaxLevel;

    // sát thương đã nhân hệ số passive
    protected float CurrentDamage => data.DamageAt(level) * Mult(StatType.Damage);

    void Awake() => stats = GetComponentInParent<PlayerStats>();

    void Update()
    {
        if (data == null) return;
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0f)
        {
            Attack();
            // tốc đánh cao hơn → cooldown ngắn hơn
            cooldownTimer = data.CooldownAt(level) / Mult(StatType.AttackSpeed);
        }
    }

    protected abstract void Attack();
    public void LevelUp() { if (level < data.MaxLevel) level++; }

    protected void FireProjectile(Vector2 dir)
    {
        var p = PoolManager.Instance.Spawn(data.projectilePrefab, transform.position, Quaternion.identity);
        p.GetComponent<Projectile>().Init(dir, CurrentDamage);
    }

    private float Mult(StatType t) => stats != null ? stats.Get(t) : 1f;
}