using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Upgradable>(out var upgradable))
        {
            ApplyUpgrade(upgradable);
        }
    }

    protected abstract void ApplyUpgrade(Upgradable upgradable);

}
