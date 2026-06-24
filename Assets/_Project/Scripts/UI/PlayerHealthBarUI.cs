using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image fill;             // Image Type = Filled, Horizontal
    [SerializeField] private TextMeshProUGUI label;  // tùy chọn: "80/100"

    void OnEnable() => playerHealth.OnDamaged += UpdateBar;
    void OnDisable() => playerHealth.OnDamaged -= UpdateBar;

    void Start()
    {
        fill.fillAmount = 1f;   // đầy lúc đầu
        Refresh();
    }

    private void UpdateBar(float pct)
    {
        fill.fillAmount = pct;
        Refresh();
    }

    private void Refresh()
    {
        if (label != null)
            label.text = Mathf.CeilToInt(playerHealth.CurrentHealth) + "/" +
                         Mathf.CeilToInt(playerHealth.MaxHealth);
    }
}