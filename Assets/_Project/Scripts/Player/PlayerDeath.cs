using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour
{
    private Health health;
    void Awake() => health = GetComponent<Health>();

    void OnEnable() => health.OnDeath += Die;
    void OnDisable() => health.OnDeath -= Die;

    private void Die() => GameEvents.RaisePlayerDied();
}