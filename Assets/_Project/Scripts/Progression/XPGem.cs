using UnityEngine;

[RequireComponent(typeof(PooledObject))]
public class XPGem : MonoBehaviour, IPoolable
{
    [SerializeField] private int xpValue = 1;
    [SerializeField] private float magnetRange = 2.5f;  // vào tầm này thì bị hút
    [SerializeField] private float moveSpeed = 8f;

    private Transform player;
    private PooledObject pooled;

    void Awake() => pooled = GetComponent<PooledObject>();

    public void OnSpawn()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        player = p != null ? p.transform : null;
    }
    public void OnDespawn() { }

    void Update()
    {
        if (player == null) return;

        if (Vector2.Distance(transform.position, player.position) <= magnetRange)
        {
            // hút dần về phía player
            transform.position = Vector2.MoveTowards(
                transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<PlayerExperience>(out var xp))
                xp.AddXP(xpValue);
            pooled.ReturnToPool();   // nhặt xong về pool
        }
    }
}