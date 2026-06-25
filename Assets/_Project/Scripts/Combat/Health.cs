using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    private float currentHealth;
    private bool isDead;

    public event Action OnDeath;
    public event Action<float> OnDamaged;
    public event Action<float> OnHit;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    void OnEnable()   // chạy mỗi khi object bật lên (kể cả khi lấy từ pool)
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;          // tránh "chết 2 lần"
        currentHealth -= amount;
        OnHit?.Invoke(amount);
        OnDamaged?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0f)
        {
            isDead = true;
            OnDeath?.Invoke();       // CHỈ báo tin — KHÔNG Destroy nữa
        }
    }
}