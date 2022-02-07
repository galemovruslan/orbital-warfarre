using UnityEngine;

[RequireComponent(typeof(ProjectilePool))]
public class Weapon : MonoBehaviour, ISwapProgression
{
    [SerializeField] private ProgressionItem _weaponStock;
    [SerializeField] private ProjectileItem _projectile;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private EventAsset OnLevelUp;
    [Range(1,3)][SerializeField] private int _level = 1;

    private WeaponItem _weaponItem;
    private ProjectilePool _pool;
    private UpgradableVisuals _visuals;

    private float _nextFireTime = 0f;
    private bool isEnabled = false;

    private void Awake()
    {
        _visuals = GetComponentInChildren<UpgradableVisuals>();
        _pool = GetComponent<ProjectilePool>();

        
    }

    private void Start()
    {
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
        _visuals.Show();
    }

    public void DisableWeapon()
    {
        isEnabled = false;
        _visuals.Hide();
    }

    private void SetWeapon(WeaponItem item)
    {
        _weaponItem = item;
        UpdateVisuals(_weaponItem);
        FireOnLevelUpEvent();
    }

    private void FireOnLevelUpEvent()
    {
        if (OnLevelUp == null) { return; }
        OnLevelUp.Invoke(_level);
    }

    private void UpdateVisuals(WeaponItem item)
    {
        if (_weaponItem == null) { return; }

        _visuals.SetVisuals(item.Visuals);

        if (!isEnabled)
        {
            _visuals.Hide();
        }
    }

}
