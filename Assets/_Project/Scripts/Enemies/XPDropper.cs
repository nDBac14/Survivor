using UnityEngine;

[RequireComponent(typeof(Health))]
public class XPDropper : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;
    private Health health;

    void Awake() => health = GetComponent<Health>();

    void OnEnable() => health.OnDeath += DropGem;   // đăng ký nghe
    void OnDisable() => health.OnDeath -= DropGem;   // huỷ đăng ký

    private void DropGem()
    {
        PoolManager.Instance.Spawn(gemPrefab, transform.position, Quaternion.identity);
    }
}