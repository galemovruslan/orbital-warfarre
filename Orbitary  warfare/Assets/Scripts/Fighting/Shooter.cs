using System.Collections.Generic;
using UnityEngine;

public enum ShooterType
{
    none,
    player,
    enemy
}

public class Shooter : MonoBehaviour, IHaveShooterType
{
    public ShooterType Type => _shooterType;

    [SerializeField] private WeaponSlot[] _weaponSlots;
    [SerializeField] private ShooterType _shooterType;

    private void Awake()
    {
        _weaponSlots = GetComponentsInChildren<WeaponSlot>();
    }

    public void Shoot(bool shoot)
    {
        if (!shoot) { return; }

        foreach (var weaponSlot in _weaponSlots)
        {
            weaponSlot.Fire( _shooterType);
        }
    }

    public List<Weapon> GetWeapons()
    {
        if(_weaponSlots == null) { return null; }

        var weapons = new List<Weapon>();

        foreach (var weaponSlot in _weaponSlots)    
        {
            weapons.Add(weaponSlot.Weapon);
        }

        return weapons;
    }

}
