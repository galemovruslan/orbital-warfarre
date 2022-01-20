using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgraderBase : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var upgradables = collision.GetComponentsInChildren<UpgradableTag>();
        if(upgradables ==null) { return; }

        foreach (var upgradable in upgradables)
        {
            ApplyUpgrade(upgradable);
        }

        /*
        if(collision.TryGetComponent<UpgradableTag>(out var upgradable))
        {
            ApplyUpgrade(upgradable);
        }
        */
    }

    protected abstract void ApplyUpgrade(UpgradableTag upgradable);
    
}
