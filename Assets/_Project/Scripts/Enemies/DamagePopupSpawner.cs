using UnityEngine;

[RequireComponent(typeof(Health))]
public class DamagePopupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab;
    private Health health;

    void Awake() => health = GetComponent<Health>();
    void OnEnable() => health.OnHit += Spawn;
    void OnDisable() => health.OnHit -= Spawn;

    private void Spawn(float amount)
    {
        var go = PoolManager.Instance.Spawn(
            popupPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        go.GetComponent<DamagePopup>().Setup(amount);
    }
}