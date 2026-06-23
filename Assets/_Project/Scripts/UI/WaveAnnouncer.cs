using System.Collections;
using TMPro;
using UnityEngine;

public class WaveAnnouncer : MonoBehaviour
{
    [SerializeField] private WaveSpawner spawner;
    [SerializeField] private TextMeshProUGUI label;   // kéo WaveWarningText vào
    [SerializeField] private float showDuration = 2.5f;

    void OnEnable() => spawner.OnAnnounce += Show;
    void OnDisable() => spawner.OnAnnounce -= Show;

    private void Show(string text)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(text));
    }

    private IEnumerator ShowRoutine(string text)
    {
        label.text = text;
        label.gameObject.SetActive(true);       // hiện chữ
        yield return new WaitForSeconds(showDuration);
        label.gameObject.SetActive(false);      // ẩn lại
    }
}