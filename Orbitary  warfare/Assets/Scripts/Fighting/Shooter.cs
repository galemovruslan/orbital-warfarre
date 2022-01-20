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

    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private ShooterType _shooterType;

    private void Awake()
    {
        _weapons = GetComponentsInChildren<Weapon>();
    }

    public void Shoot(bool shoot)
    {
        if (!shoot) { return; }

        foreach (var weaponSlot in _weapons)
        {
            weaponSlot.Fire( _shooterType);
        }
    }

    public bool SetWeaponProgression(ProgressionItem progression)
    {
        if(_weapons == null) { return false; }

        foreach (var weapon in _weapons)
        {
            weapon.SetNewProgression(progression, 1);
        }
        return true;
    }

    public void LevelUpWeapon()
    {
        foreach (var weapon in _weapons)
        {
            weapon.LevelUp();
        }
    }

    public bool SetProjectileProgression(ProgressionItem progression)
    {
        if (_weapons == null) { return false; }

        foreach (var weapon in _weapons)
        {
            weapon.SetNewProjectile(progression);
        }
        return true;
    }

}
