using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Weapon Weapon { get => _weapon; }

    [SerializeField] private Weapon _weapon;

    private void Awake()
    {
        _weapon = Instantiate<Weapon>(_weapon, transform);
    }

    public void Fire(ShooterType shooterType)
    {
        if(_weapon == null) { return; }

        _weapon.Fire(shooterType);
    }
}
