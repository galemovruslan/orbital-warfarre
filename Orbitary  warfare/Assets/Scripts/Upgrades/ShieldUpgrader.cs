using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrader : UpgraderBase
{
    protected override void ApplyUpgrade(UpgradableTag upgradable)
    {
        if(upgradable.TryGetComponent<Shield>(out var shield))
        {
            shield.LevelUp();
        }

    }
}