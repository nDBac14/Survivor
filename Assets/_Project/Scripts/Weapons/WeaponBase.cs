using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected WeaponData data;
    protected int level = 1;
    private float cooldownTimer;

    public WeaponData Data => data;
    public int Level => level;
    public bool IsMaxLevel => level >= data.MaxLevel;

    void Update()
    {
        if (data == null) return;
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0f)
        {
            Attack();                          // mỗi vũ khí làm khác nhau
            cooldownTimer = data.CooldownAt(level);
        }
    }

    protected abstract void Attack();          // ĐIỂM MỞ RỘNG (Strategy)

    public void LevelUp()
    {
        if (level < data.MaxLevel) level++;
    }

    // Hàm chung cho vũ khí dùng đạn (tạo đạn qua pool — Factory + Object Pool)
    protected void FireProjectile(Vector2 dir)
    {
        var p = PoolManager.Instance.Spawn(data.projectilePrefab, transform.position, Quaternion.identity);
        p.GetComponent<Projectile>().Init(dir, data.DamageAt(level));
    }
}