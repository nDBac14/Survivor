using UnityEngine;

public class EvolveUpgrade : IUpgrade
{
    private readonly WeaponManager manager;
    private readonly WeaponBase baseWeapon;
    private readonly GameObject evolvedPrefab;
    private readonly string evolvedName;

    public EvolveUpgrade(WeaponManager manager, WeaponBase baseWeapon)
    {
        this.manager = manager;
        this.baseWeapon = baseWeapon;
        this.evolvedPrefab = baseWeapon.Data.evolvedWeaponPrefab;
        this.evolvedName = evolvedPrefab.GetComponent<WeaponBase>().Data.weaponName;
    }

    public string Title => "★ TIẾN HÓA: " + evolvedName;
    public string Description => "Tiến hóa từ " + baseWeapon.Data.weaponName;

    public void Apply()
    {
        manager.RemoveWeapon(baseWeapon);     // bỏ vũ khí gốc
        manager.AddWeapon(evolvedPrefab);     // thay bằng vũ khí tiến hóa
    }
}