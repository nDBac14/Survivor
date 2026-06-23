using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;   
    [SerializeField] private int prewarm = 30;

    private readonly Queue<PooledObject> available = new Queue<PooledObject>();
    private bool initialized;

    void Awake()
    {
        if (prefab != null) Initialize();   // dùng khi set sẵn trong Inspector (đạn)
    }

    // gọi khi tạo pool bằng code (PoolManager dùng)
    public void Configure(GameObject prefab, int prewarm)
    {
        this.prefab = prefab;
        this.prewarm = prewarm;
        Initialize();
    }

    private void Initialize()
    {
        if (initialized) return;
        initialized = true;
        for (int i = 0; i < prewarm; i++)
        {
            var po = CreateNew();
            po.gameObject.SetActive(false);
            available.Enqueue(po);
        }
    }

    private PooledObject CreateNew()
    {
        GameObject obj = Instantiate(prefab, transform);
        PooledObject po = obj.GetComponent<PooledObject>();
        if (po == null) po = obj.AddComponent<PooledObject>();
        po.Pool = this;
        return po;
    }

    public GameObject Get(Vector3 position, Quaternion rotation)
    {
        PooledObject po = available.Count > 0 ? available.Dequeue() : CreateNew();
        po.transform.SetPositionAndRotation(position, rotation);
        po.gameObject.SetActive(true);
        po.HandleSpawn();
        return po.gameObject;
    }

    public void Release(PooledObject po)
    {
        po.HandleDespawn();
        po.gameObject.SetActive(false);
        available.Enqueue(po);
    }
}