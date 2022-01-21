using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrader : UpgraderBase
{
    protected override void ApplyUpgrade(UpgradableTag upgradable)
    {
        if(upgradable.TryGetComponent<Weapon>(out var weapon))
        {
            weapon.LevelUp();
            Destroy(gameObject);
        }
    }
}
