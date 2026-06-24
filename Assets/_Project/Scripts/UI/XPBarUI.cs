using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBarUI : MonoBehaviour
{
    [SerializeField] private PlayerExperience experience;
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI levelLabel;

    void OnEnable()
    {
        experience.OnXPChanged += UpdateBar;
        experience.OnLevelUp += UpdateLevel;
    }
    void OnDisable()
    {
        experience.OnXPChanged -= UpdateBar;
        experience.OnLevelUp -= UpdateLevel;
    }

    void Start()
    {
        fill.fillAmount = 0f;
        UpdateLevel(experience.Level);
    }

    private void UpdateBar(int current, int toNext)
        => fill.fillAmount = toNext > 0 ? (float)current / toNext : 0f;

    private void UpdateLevel(int level)
        => levelLabel.text = "Lv " + level;
}