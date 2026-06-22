using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    private float current;

    public event Action OnDeath;            // Observer: nơi khác lắng nghe
    public event Action<float> OnDamaged;   // truyền % máu còn lại

    void OnEnable() => current = maxHealth;

    public void TakeDamage(float amount)
    {
        current -= amount;
        OnDamaged?.Invoke(current / maxHealth);
        if (current <= 0f)
        {
            OnDeath?.Invoke();
            Destroy(gameObject); 
        }
    }
}