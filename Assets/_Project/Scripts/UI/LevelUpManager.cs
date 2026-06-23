using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private PlayerExperience experience;
    [SerializeField] private UpgradeProvider provider;
    [SerializeField] private SkillSelectionUI ui;

    private int pending;       // số lần lên cấp đang chờ xử lý
    private bool showing;

    void OnEnable() => experience.OnLevelUp += OnLevelUp;
    void OnDisable() => experience.OnLevelUp -= OnLevelUp;

    private void OnLevelUp(int level)
    {
        pending++;
        if (!showing) ShowNext();
    }

    private void ShowNext()
    {
        var choices = provider.GetRandomChoices(3);
        if (choices.Count == 0)   // hết thứ để nâng (mọi vũ khí đã max)
        {
            pending = 0;
            Resume();
            return;
        }
        showing = true;
        Time.timeScale = 0f;      // TẠM DỪNG game
        ui.Show(choices, OnChosen);
    }

    private void OnChosen(IUpgrade upgrade)
    {
        upgrade.Apply();
        pending = Mathf.Max(0, pending - 1);
        ui.Hide();

        if (pending > 0) ShowNext();   // còn cấp chờ → hiện màn kế
        else Resume();
    }

    private void Resume()
    {
        showing = false;
        Time.timeScale = 1f;          // CHƠI TIẾP
        ui.Hide();
    }
}