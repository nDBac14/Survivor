using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image fill;     // Image Type = Filled, Horizontal

    private Health bound;

    void Awake() => panel.SetActive(false);

    void OnEnable()
    {
        GameEvents.BossSpawned += Show;
        GameEvents.BossDespawned += Hide;
    }
    void OnDisable()
    {
        GameEvents.BossSpawned -= Show;
        GameEvents.BossDespawned -= Hide;
    }

    private void Show(Health bossHealth)
    {
        bound = bossHealth;
        bound.OnDamaged += UpdateBar;
        fill.fillAmount = 1f;
        panel.SetActive(true);
    }

    private void Hide()
    {
        if (bound != null) bound.OnDamaged -= UpdateBar;
        bound = null;
        panel.SetActive(false);
    }

    private void UpdateBar(float pct) => fill.fillAmount = pct;
}