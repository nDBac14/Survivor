using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Survivor/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public Sprite icon;                  // để hiện trong màn chọn skill (Phase 6)

    [Header("Chỉ số theo cấp (phần tử 0 = cấp 1)")]
    public float[] damage = { 10f };
    public float[] cooldown = { 1f };
    public int[] projectileCount = { 1 };
    public float range = 8f;

    public GameObject projectilePrefab;  // vũ khí dùng đạn thì gán; vùng sát thương để trống

    public int MaxLevel => damage.Length;

    public float DamageAt(int level) => damage[Clamp(level, damage.Length)];
    public float CooldownAt(int level) => cooldown[Clamp(level, cooldown.Length)];
    public int CountAt(int level) => projectileCount[Clamp(level, projectileCount.Length)];

    private int Clamp(int level, int arrayLength) => Mathf.Clamp(level - 1, 0, arrayLength - 1);
}