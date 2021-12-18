using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private Weapon _weapon;

    public void Shoot(bool shoot)
    {
        if (!shoot) { return; }

        _weapon.Fire(transform.position, transform.rotation);
    }

}
