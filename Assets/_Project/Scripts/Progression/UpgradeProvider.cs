using System.Collections.Generic;
using UnityEngine;

public class UpgradeProvider : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private PassiveManager passiveManager;
    [SerializeField] private List<GameObject> allWeapons = new List<GameObject>();
    [SerializeField] private List<PassiveData> allPassives = new List<PassiveData>();

    public List<IUpgrade> GetRandomChoices(int count)
    {
        var pool = BuildPool();
        for (int i = pool.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (pool[i], pool[j]) = (pool[j], pool[i]);
        }
        if (pool.Count > count) pool.RemoveRange(count, pool.Count - count);
        return pool;
    }

    private List<IUpgrade> BuildPool()
    {
        var pool = new List<IUpgrade>();

        // --- Vũ khí ---
        foreach (var prefab in allWeapons)
        {
            var data = prefab.GetComponent<WeaponBase>().Data;
            if (weaponManager.HasWeapon(data))
            {
                var weapon = weaponManager.GetWeapon(data);
                if (!weapon.IsMaxLevel)
                {
                    pool.Add(new LevelUpWeaponUpgrade(weapon));
                }
                else if (CanEvolve(data))   // max rồi & đủ điều kiện → tiến hóa
                {
                    pool.Add(new EvolveUpgrade(weaponManager, weapon));
                }
            }
            else
            {
                pool.Add(new AddWeaponUpgrade(weaponManager, prefab));
            }
        }

        // --- Passive ---
        foreach (var p in allPassives)
        {
            if (!passiveManager.IsMaxed(p))
                pool.Add(new PassiveUpgrade(passiveManager, p));
        }

        return pool;
    }

    private bool CanEvolve(WeaponData data) =>
        data.evolvedWeaponPrefab != null &&
        data.requiredPassive != null &&
        passiveManager.Has(data.requiredPassive);
}