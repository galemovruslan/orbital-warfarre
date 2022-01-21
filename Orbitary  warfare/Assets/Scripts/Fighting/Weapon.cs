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
    private bool isEnabled = false;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _pool = GetComponent<ProjectilePool>();

        if (_weaponStock != null)
        {
            SetWeapon(_weaponStock.GetItem(_level) as WeaponItem);
        }
    }

    private void OnValidate()
    {
        if (_weaponStock.Type != ProgressionItem.ItemType.Weapon)
        {
            _weaponStock = null;
        }
    }

    public void Fire(ShooterType shooterType)
    {
        if (!isEnabled) { return; }

        if (Time.time >= _nextFireTime)
        {
            if (_pool == null)
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
        if (_weaponStock == weaponStock ||
            weaponStock.Type != ProgressionItem.ItemType.Weapon
            ) 
            { return; }

        _weaponStock = weaponStock;
        _level = level;
        SetWeapon(_weaponStock.GetItem(level) as WeaponItem);
    }

    public void SetNewProjectile(ProgressionItem projectileStock)
    {
        if (projectileStock.Type != ProgressionItem.ItemType.Projectile) { return; }

        _projectile = projectileStock.GetItem(level: 1) as ProjectileItem;
        _pool.RepopulatePool(_projectile);
    }

    public void LevelUp()
    {
        if (_level >= _weaponStock.MaxLevel) { return; }

        _level++;
        SetWeapon(_weaponStock.GetItem(_level) as WeaponItem);
    }

    public void EnableWeapon()
    {
        isEnabled = true;
        _renderer.enabled = true;
    }

    public void DisableWeapon()
    {
        isEnabled = false;
        _renderer.enabled = false;
    }

    private void SetWeapon(WeaponItem item)
    {
        _weaponItem = item;
        _renderer.sprite = item.Sprite;
        _renderer.color = item.Color;
    }

}
