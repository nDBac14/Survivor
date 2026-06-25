using UnityEngine;

[RequireComponent(typeof(PooledObject))]
public class PooledVFX : MonoBehaviour, IPoolable
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private float lifetime = 0.6f;

    private PooledObject pooled;
    private float timer;

    void Awake() => pooled = GetComponent<PooledObject>();

    public void OnSpawn()
    {
        timer = lifetime;
        if (ps) ps.Play();            // phát lại mỗi lần lấy từ pool
    }
    public void OnDespawn() { }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f) pooled.ReturnToPool();
    }
}