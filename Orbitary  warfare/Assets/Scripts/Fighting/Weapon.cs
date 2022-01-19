using UnityEngine;

[RequireComponent(typeof(ProjectilePool))]
public class Weapon : MonoBehaviour, ISwapProgression
{
    [SerializeField] private ProgressionItem _weaponStock;
    [SerializeField] private ProjectileItem _projectile;
    [SerializeField] Transform _firePoint;

    private WeaponItem _weaponItem;
    private ProjectilePool _pool;
    private SpriteRenderer _renderer;

    private float _nextFireTime = 0f;
    private int _level = 1;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _pool = GetComponent<ProjectilePool>();

        if(_weaponStock != null)
        {
            SetWeapon(_weaponStock.GetItem(_level) as WeaponItem);
        }
    }

    private void OnValidate()
    {
        if(_weaponStock.Type != ProgressionItem.ItemType.Weapon)
        {
            _weaponStock = null;
        }
    }

    public void Fire(ShooterType shooterType)
    {
        if (Time.time >= _nextFireTime)
        {
            if(_pool == null)
            {
                _pool = GetComponent<ProjectilePool>();
            }

            Projectile nextProjectile = _pool.GetItem(_projectile);
            nextProjectile.transform.position = _firePoint.position;
            nextProjectile.transform.rotation = _firePoint.rotation;

            nextProjectile.Launch(_projectile.Speed, _projectile.Damage, shooterType);

            _nextFireTime = Time.time + _weaponItem.TimeBetweenShots;
        }
    }

    public void SetNewProgression(ProgressionItem weaponStock, int level)
    {
        if(weaponStock.Type != ProgressionItem.ItemType.Weapon) { return; }

        _weaponStock = weaponStock;
        _level = level;
        SetWeapon(_weaponStock.GetItem(level) as WeaponItem);
    }

    private void SetWeapon(WeaponItem item)
    {
        _weaponItem = item;
        _renderer.sprite = item.Sprite;
        _renderer.color = item.Color;
    }

}
