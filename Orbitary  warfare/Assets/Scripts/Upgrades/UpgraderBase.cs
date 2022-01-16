using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgraderBase : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<UpgradableTag>(out var upgradable))
        {
            ApplyUpgrade(upgradable);
        }
    }

    protected abstract void ApplyUpgrade(UpgradableTag upgradable);

}
