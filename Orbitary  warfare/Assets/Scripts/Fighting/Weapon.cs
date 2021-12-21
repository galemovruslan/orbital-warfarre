using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectilePool))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponItem _weaponItem;
    [SerializeField] private ProjectileItem _projectile;
    [SerializeField] Transform _firePoint;
    [SerializeField] private ProjectilePool _pool;

    private float _nextFireTime = 0f;

    private void Awake()
    {
        _pool = GetComponent<ProjectilePool>();
    }

    public void Fire(ShooterType shooterType)
    {
        if (Time.time >= _nextFireTime)
        {
            Projectile nextProjectile = _pool.GetItem(_projectile);
            PrepareProjectile(nextProjectile);
            nextProjectile.Launch(_projectile.Speed, _projectile.Damage, shooterType);

            _nextFireTime = Time.time + _weaponItem.TimeBetweenShots;
        }
    }

    private void PrepareProjectile(Projectile projectile)
    {
        projectile.transform.position = _firePoint.position;
        projectile.transform.rotation = _firePoint.rotation;
    }

}
