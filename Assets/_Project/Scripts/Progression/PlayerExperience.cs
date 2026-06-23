using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private int baseXPToLevel = 5;       // XP cần cho cấp 2
    [SerializeField] private int xpIncreasePerLevel = 3;  // mỗi cấp cần thêm bao nhiêu

    private int currentXP;
    private int level = 1;
    private int xpToNext;

    public int Level => level;

    public event Action<int, int> OnXPChanged;  // (XP hiện tại, XP cần cho cấp sau)
    public event Action<int> OnLevelUp;         // (cấp mới)

    void Awake() => xpToNext = baseXPToLevel;
    public void AddXP(int amount)
    {
        currentXP += amount;

        // có thể lên nhiều cấp một lúc nếu nhặt nhiều XP
        while (currentXP >= xpToNext)
        {
            currentXP -= xpToNext;
            level++;
            xpToNext = baseXPToLevel + (level - 1) * xpIncreasePerLevel;
            OnLevelUp?.Invoke(level);
        }

        OnXPChanged?.Invoke(currentXP, xpToNext);
    }
}