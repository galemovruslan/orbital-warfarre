using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLayoutUpgrader : UpgraderBase
{
   
protected override void ApplyUpgrade(UpgradableTag upgradable)
    {
        if(upgradable.TryGetComponent<WeaponSlot>(out var weaponSlot))
        {
            weaponSlot.LevelUp();
            Destroy(gameObject);
        }
    }
}
