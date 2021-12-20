using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponItem _weaponItem;
    [SerializeField] private ProjectileItem _projectile;
    [SerializeField] Transform _firePoint;

    private float _nextFireTime = 0f;

    public void Fire(ShooterType shooterType)
    {
        if (Time.time >= _nextFireTime)
        {
            _projectile.Fire(_firePoint.position, _firePoint.rotation, shooterType);
            _nextFireTime = Time.time + _weaponItem.TimeBetweenShots;
        }
    }
}
