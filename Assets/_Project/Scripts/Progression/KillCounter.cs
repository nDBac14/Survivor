using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int kills;
    public int Kills => kills;

    void OnEnable() => GameEvents.EnemyKilled += OnKill;
    void OnDisable() => GameEvents.EnemyKilled -= OnKill;

    private void OnKill()
    {
        kills++;
        Debug.Log("Kills: " + kills); 
    }
}