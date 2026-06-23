public class LevelUpWeaponUpgrade : IUpgrade
{
    private readonly WeaponBase weapon;

    public LevelUpWeaponUpgrade(WeaponBase weapon) { this.weapon = weapon; }

    public string Title => "Nâng cấp: " + weapon.Data.weaponName;
    public string Description => "Cấp " + weapon.Level + " → " + (weapon.Level + 1);

    public void Apply() => weapon.LevelUp();
}