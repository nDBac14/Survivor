using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [SerializeField] private int defaultPrewarm = 30;
    private readonly Dictionary<GameObject, ObjectPool> pools =
        new Dictionary<GameObject, ObjectPool>();

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    private ObjectPool GetPool(GameObject prefab)
    {
        if (!pools.TryGetValue(prefab, out var pool))
        {
            var go = new GameObject("Pool_" + prefab.name);
            go.transform.SetParent(transform);
            pool = go.AddComponent<ObjectPool>();
            pool.Configure(prefab, defaultPrewarm);   // tạo pool mới cho prefab này
            pools[prefab] = pool;
        }
        return pool;
    }

    public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
        => GetPool(prefab).Get(pos, rot);
}