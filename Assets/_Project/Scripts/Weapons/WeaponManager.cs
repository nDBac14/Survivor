using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;            // object con của Player
    [SerializeField] private List<GameObject> startingWeapons = new List<GameObject>();

    private readonly List<WeaponBase> activeWeapons = new List<WeaponBase>();
    public IReadOnlyList<WeaponBase> ActiveWeapons => activeWeapons;

    void Start()
    {
        foreach (var prefab in startingWeapons) AddWeapon(prefab);
    }

    public WeaponBase AddWeapon(GameObject weaponPrefab)
    {
        var go = Instantiate(weaponPrefab, weaponHolder);
        go.transform.localPosition = Vector3.zero;
        var weapon = go.GetComponent<WeaponBase>();
        activeWeapons.Add(weapon);
        return weapon;
    }
    public void RemoveWeapon(WeaponBase weapon)
    {
        activeWeapons.Remove(weapon);
        Destroy(weapon.gameObject);
    }

    public bool HasWeapon(WeaponData data) => activeWeapons.Exists(w => w.Data == data);
    public WeaponBase GetWeapon(WeaponData data) => activeWeapons.Find(w => w.Data == data);
}