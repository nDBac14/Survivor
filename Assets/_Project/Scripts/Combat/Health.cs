using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    private float current;
    private bool isDead;

    public event Action OnDeath;
    public event Action<float> OnDamaged;

    void OnEnable()   // chạy mỗi khi object bật lên (kể cả khi lấy từ pool)
    {
        current = maxHealth;
        isDead = false;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;          // tránh "chết 2 lần"
        current -= amount;
        OnDamaged?.Invoke(current / maxHealth);

        if (current <= 0f)
        {
            isDead = true;
            OnDeath?.Invoke();       // CHỈ báo tin — KHÔNG Destroy nữa
        }
    }
}