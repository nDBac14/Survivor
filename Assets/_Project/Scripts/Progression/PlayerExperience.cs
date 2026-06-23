using System;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    private int currentXP;
    public int CurrentXP => currentXP;

    public event Action<int> OnXPChanged;  

    public void AddXP(int amount)
    {
        currentXP += amount;
        OnXPChanged?.Invoke(currentXP);
        Debug.Log("XP: " + currentXP); 
    }
}