using UnityEngine;

[CreateAssetMenu(fileName = "PassiveData", menuName = "Survivor/Passive Data")]
public class PassiveData : ScriptableObject
{
    public string passiveName;
    public StatType statType;
    public float amountPerLevel = 0.1f;   // +10% mỗi cấp
    public int maxLevel = 5;
}