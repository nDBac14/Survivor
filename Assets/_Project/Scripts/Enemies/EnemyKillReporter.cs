using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyKillReporter : MonoBehaviour
{
    private Health health;
    void Awake() => health = GetComponent<Health>();

    void OnEnable() => health.OnDeath += Report;
    void OnDisable() => health.OnDeath -= Report;

    private void Report() => GameEvents.RaiseEnemyKilled();
}