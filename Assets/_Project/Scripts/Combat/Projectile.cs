using UnityEngine;

[RequireComponent(typeof(PooledObject))]
public class Projectile : MonoBehaviour, IPoolable
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifeTime = 3f;

    private Vector2 direction;
    private float timer;
    private PooledObject pooled;

    void Awake() => pooled = GetComponent<PooledObject>();

    public void Init(Vector2 dir, float damage)
    {
        direction = dir.normalized;
        this.damage = damage;       // damage giờ do vũ khí quyết định, không cố định
    }

    public void OnSpawn() => timer = lifeTime;  // reset đồng hồ mỗi lần bắn
    public void OnDespawn() { }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer <= 0f) pooled.ReturnToPool();   // hết hạn -> về kho, KHÔNG Destroy
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(damage);
            pooled.ReturnToPool();                 // trúng -> về kho
        }
    }
}