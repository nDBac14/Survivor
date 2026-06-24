using UnityEngine;
using TMPro;

public class KillCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private KillCounter counter;

    void OnEnable() => GameEvents.EnemyKilled += Refresh;
    void OnDisable() => GameEvents.EnemyKilled -= Refresh;

    void Start() => Refresh();

    private void Refresh() => label.text = counter.Kills.ToString();
}