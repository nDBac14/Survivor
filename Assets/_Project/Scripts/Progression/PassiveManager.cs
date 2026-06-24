using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    private readonly Dictionary<PassiveData, int> owned = new Dictionary<PassiveData, int>();

    public bool Has(PassiveData data) => owned.ContainsKey(data);
    public int LevelOf(PassiveData data) => owned.TryGetValue(data, out var lv) ? lv : 0;
    public bool IsMaxed(PassiveData data) => LevelOf(data) >= data.maxLevel;

    public void AddOrLevel(PassiveData data)
    {
        owned[data] = LevelOf(data) + 1;
        stats.AddMultiplier(data.statType, data.amountPerLevel);
    }
}