using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Health>().OnDeath += HandleDeath;
    }

    private void HandleDeath()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;   // dừng toàn bộ game
    }
}