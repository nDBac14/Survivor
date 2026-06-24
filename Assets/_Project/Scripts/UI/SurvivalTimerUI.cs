using UnityEngine;
using TMPro;

public class SurvivalTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    private float elapsed;

    void Update()
    {
        elapsed += Time.deltaTime;   // tự dừng khi timeScale = 0 (menu/pause/gameover)
        int minutes = (int)(elapsed / 60f);
        int seconds = (int)(elapsed % 60f);
        label.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}