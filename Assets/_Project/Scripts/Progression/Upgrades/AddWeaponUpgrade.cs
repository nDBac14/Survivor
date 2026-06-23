using UnityEngine;

public class AddWeaponUpgrade : IUpgrade
{
    private readonly WeaponManager manager;
    private readonly GameObject weaponPrefab;
    private readonly WeaponData data;

    public AddWeaponUpgrade(WeaponManager manager, GameObject weaponPrefab)
    {
        this.manager = manager;
        this.weaponPrefab = weaponPrefab;
        this.data = weaponPrefab.GetComponent<WeaponBase>().Data;
    }

    public string Title => "Vũ khí mới: " + data.weaponName;
    public string Description => "Trang bị " + data.weaponName;

    public void Apply() => manager.AddWeapon(weaponPrefab);
}