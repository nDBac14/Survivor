using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PooledObject))]
public class EnemyDeath : MonoBehaviour
{
    private Health health;
    private PooledObject pooled;

    void Awake()
    {
        health = GetComponent<Health>();
        pooled = GetComponent<PooledObject>();
    }

    void OnEnable() => health.OnDeath += HandleDeath;   // đăng ký khi bật
    void OnDisable() => health.OnDeath -= HandleDeath;   // HUỶ đăng ký khi tắt

    private void HandleDeath()
    {
        
        pooled.ReturnToPool();
    }
}