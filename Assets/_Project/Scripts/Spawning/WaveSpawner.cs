using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private WaveData waveData;
    [SerializeField] private float spawnRadius = 12f;

    public event System.Action<string> OnAnnounce;  // Observer: UI nghe để hiện cảnh báo

    private Transform player;
    private float elapsed;
    private float[] timers;       // đếm ngược tới lần spawn kế cho mỗi entry
    private bool[] announced;     // mỗi entry chỉ cảnh báo 1 lần

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timers = new float[waveData.entries.Count];
        announced = new bool[waveData.entries.Count];
    }

    void Update()
    {
        elapsed += Time.deltaTime;

        for (int i = 0; i < waveData.entries.Count; i++)
        {
            var e = waveData.entries[i];

            // ngoài khung thời gian của entry này thì bỏ qua
            if (elapsed < e.startTime || elapsed > e.endTime) continue;

            // cảnh báo 1 lần khi entry bắt đầu
            if (e.announce && !announced[i])
            {
                announced[i] = true;
                OnAnnounce?.Invoke(e.announceText);
            }

            timers[i] -= Time.deltaTime;
            if (timers[i] <= 0f)
            {
                for (int n = 0; n < e.countPerSpawn; n++)
                    SpawnAround(e.enemyPrefab);
                timers[i] = e.spawnInterval;
            }
        }
    }

    void SpawnAround(GameObject prefab)
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;
        Vector2 pos = (Vector2)player.position + offset;
        PoolManager.Instance.Spawn(prefab, pos, Quaternion.identity);
    }
}