using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool Pool { get; set; }
    private IPoolable[] poolables;

    void Awake()
    {
        // cache sẵn để không phải tìm lại mỗi lần (tránh tốn hiệu năng)
        poolables = GetComponents<IPoolable>();
    }

    public void HandleSpawn()
    {
        foreach (var p in poolables) p.OnSpawn();
    }

    public void HandleDespawn()
    {
        foreach (var p in poolables) p.OnDespawn();
    }

    // GỌI CÁI NÀY THAY CHO Destroy(gameObject)
    public void ReturnToPool()
    {
        Pool.Release(this);
    }
}