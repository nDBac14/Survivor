using UnityEngine;

[RequireComponent(typeof(Health))]
public class DeathEffects : MonoBehaviour
{
    [SerializeField] private GameObject deathVfxPrefab;
    [SerializeField] private AudioClip deathSound;   
    private Health health;

    void Awake() => health = GetComponent<Health>();
    void OnEnable() => health.OnDeath += Play;
    void OnDisable() => health.OnDeath -= Play;

    private void Play()
    {
        if (deathVfxPrefab)
            PoolManager.Instance.Spawn(deathVfxPrefab, transform.position, Quaternion.identity);

        if (deathSound && AudioManager.Instance)      
            AudioManager.Instance.PlaySFX(deathSound);
    }
}