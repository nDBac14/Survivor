using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSelectionUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button[] buttons;             // 3 nút
    [SerializeField] private TextMeshProUGUI[] labels;     // 3 chữ trên nút

    private Action<IUpgrade> onChosen;
    private List<IUpgrade> current;

    void Awake() => panel.SetActive(false);

    public void Show(List<IUpgrade> choices, Action<IUpgrade> callback)
    {
        current = choices;
        onChosen = callback;
        panel.SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            bool has = i < choices.Count;
            buttons[i].gameObject.SetActive(has);
            if (!has) continue;

            labels[i].text = choices[i].Title + "\n<size=70%>" + choices[i].Description + "</size>";

            int index = i;   // (nếu dùng i trực tiếp, mọi nút sẽ trỏ tới phần tử cuối)
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => onChosen?.Invoke(current[index]));
        }
    }

    public void Hide() => panel.SetActive(false);
}