using TMPro;
using UnityEngine;

[RequireComponent(typeof(PooledObject))]
public class DamagePopup : MonoBehaviour, IPoolable
{
    [SerializeField] private TextMeshPro text;    
    [SerializeField] private float lifetime = 0.6f;
    [SerializeField] private float floatSpeed = 2f;

    private PooledObject pooled;
    private Color baseColor;
    private float timer;

    void Awake()
    {
        pooled = GetComponent<PooledObject>();
        baseColor = text.color;
    }

    public void Setup(float amount) => text.text = Mathf.RoundToInt(amount).ToString();

    public void OnSpawn()
    {
        timer = lifetime;
        text.color = baseColor;
    }
    public void OnDespawn() { }

    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;  // bay lên

        Color c = text.color;
        c.a = Mathf.Clamp01(timer / lifetime);   // mờ dần
        text.color = c;

        if (timer <= 0f) pooled.ReturnToPool();
    }
}