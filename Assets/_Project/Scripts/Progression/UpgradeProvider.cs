using System.Collections.Generic;
using UnityEngine;

public class UpgradeProvider : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private List<GameObject> allWeapons = new List<GameObject>();

    public List<IUpgrade> GetRandomChoices(int count)
    {
        var pool = BuildPool();

        // xáo trộn (Fisher-Yates)
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
        foreach (var prefab in allWeapons)
        {
            var data = prefab.GetComponent<WeaponBase>().Data;
            if (weaponManager.HasWeapon(data))
            {
                var weapon = weaponManager.GetWeapon(data);
                if (!weapon.IsMaxLevel)
                    pool.Add(new LevelUpWeaponUpgrade(weapon));   // có rồi & chưa max → nâng cấp
            }
            else
            {
                pool.Add(new AddWeaponUpgrade(weaponManager, prefab)); // chưa có → thêm mới
            }
        }
        return pool;
    }
}