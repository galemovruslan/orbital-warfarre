using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : Upgrade
{
    protected override void ApplyUpgrade(Upgradable upgradable)
    {
        Shield shield;

        if(!upgradable.TryGetComponent<Shield>(out shield))
        {
            return;
        }

        ShieldItem upgradedShield = Stock.Instance.GetShield(shield.Level + 1);
        if(upgradedShield == null)
        {
            return;
        }
        shield.SetShield(upgradedShield);
    }
}
