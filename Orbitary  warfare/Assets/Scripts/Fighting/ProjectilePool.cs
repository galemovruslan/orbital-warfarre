using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private int _poolSize = 20;

    private readonly string _parentName = "Projectile Storage";

    private GameObject _itemParent;
    private Projectile _projectile;
    private List<Projectile> _pool;
    private bool _initialized = false;

    private void OnEnable()
    {
        _pool = new List<Projectile>();
        _initialized = false;
    }

    private void OnDestroy()
    {
        foreach (var item in _pool)
        {
            if (item != null)
            {
                Destroy(item.gameObject);
            }
        }
        _pool.Clear();
    }

    public Projectile GetItem(ProjectileItem projectileSO)
    {
        if (!_initialized)
        {
            _itemParent = GameObject.Find(_parentName);
            if (_itemParent == null)
            {
                _itemParent = new GameObject(_parentName);
            }
            _projectile = projectileSO.Projectile;
            for (int poolIndex = 0; poolIndex < _poolSize; poolIndex++)
            {
                _pool.Add(MakeItem(false));
            }
            _initialized = true;
        }
        return GetItem();
    }

    public Projectile GetItem()
    {
        foreach (var projectile in _pool)
        {
            if (!projectile.isActiveAndEnabled)
            {
                projectile.gameObject.SetActive(true);
                return projectile;
            }
        }
        var newProjectile = MakeItem(true);
        _pool.Add(newProjectile);
        return newProjectile;
    }

    public void ReturnItem(Projectile returnedItem)
    {
        returnedItem.transform.position = transform.position;
        returnedItem.transform.rotation = transform.rotation;
        returnedItem.gameObject.SetActive(false);
    }

    private Projectile MakeItem(bool isActive)
    {
        Projectile createdProjectile = Instantiate<Projectile>(_projectile, transform.position, transform.rotation, _itemParent.transform);
        createdProjectile.gameObject.SetActive(isActive);
        createdProjectile.Pool = this;
        return createdProjectile;
    }

}
