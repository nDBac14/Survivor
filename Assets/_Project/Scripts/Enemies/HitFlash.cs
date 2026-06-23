using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Health))]
public class HitFlash : MonoBehaviour
{
    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float duration = 0.08f;

    private SpriteRenderer sr;
    private Color original;
    private Health health;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        original = sr.color;
        health = GetComponent<Health>();
    }

    void OnEnable() => health.OnDamaged += Flash;
    void OnDisable()
    {
        health.OnDamaged -= Flash;
        StopAllCoroutines();
        sr.color = original;   // trả màu gốc khi về pool, kẻo lần sau bị kẹt màu trắng
    }

    private void Flash(float _)   // không cần dùng giá trị % máu
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        sr.color = flashColor;
        yield return new WaitForSeconds(duration);
        sr.color = original;
    }
}