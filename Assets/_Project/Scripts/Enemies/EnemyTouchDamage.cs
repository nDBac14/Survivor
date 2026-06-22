using UnityEngine;

public class EnemyTouchDamage : MonoBehaviour
{
    [SerializeField] private float damagePerHit = 5f;
    [SerializeField] private float damageInterval = 0.5f; // tránh trừ máu mỗi frame
    private float timer;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (collision.collider.TryGetComponent<Health>(out var hp))
                hp.TakeDamage(damagePerHit);
            timer = damageInterval;
        }
    }
}