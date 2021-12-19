using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private WeaponItem _weapon;
    [SerializeField] private WeaponSlot[] _weaponSlots;

    private void Awake()
    {
        _weaponSlots = GetComponentsInChildren<WeaponSlot>();
    }

    public void Shoot(bool shoot)
    {
        if (!shoot) { return; }

        foreach (var weaponSlot in _weaponSlots)
        {
            weaponSlot.Fire();
        }
    }

}
