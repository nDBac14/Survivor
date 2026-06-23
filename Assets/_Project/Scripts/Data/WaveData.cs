using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Survivor/Wave Data")]
public class WaveData : ScriptableObject
{
    [System.Serializable]
    public class SpawnEntry
    {
        public string label;              // ghi chú để dễ đọc trong Inspector
        public float startTime;           // giây bắt đầu xuất hiện
        public float endTime = 9999f;     // giây kết thúc
        public GameObject enemyPrefab;    // loại quái
        public float spawnInterval = 1f;  // mỗi lần spawn cách nhau bao lâu (giây)
        public int countPerSpawn = 1;     // mỗi lần spawn ra mấy con

        [Header("Cảnh báo")]
        public bool announce;             // có hiện chữ cảnh báo không
        public string announceText = "ZOMBIES INCOMING";
    }

    public List<SpawnEntry> entries = new List<SpawnEntry>();
}