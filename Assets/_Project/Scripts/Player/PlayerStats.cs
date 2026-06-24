using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private readonly Dictionary<StatType, float> multipliers = new Dictionary<StatType, float>();
    public event Action OnStatsChanged;

    public float Get(StatType type) =>
        multipliers.TryGetValue(type, out var v) ? v : 1f;   // mặc định 100%

    public void AddMultiplier(StatType type, float amount)
    {
        multipliers[type] = Get(type) + amount;
        OnStatsChanged?.Invoke();
    }
}