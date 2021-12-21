using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private int _poolSize = 20;

    private Projectile _projectile;
    private List<Projectile> _pool = new List<Projectile>();

    public Projectile GetItem(ProjectileItem projectileSO)
    {
        if(_projectile == null)
        {
            _projectile = projectileSO.Projectile;
            for (int poolIndex = 0; poolIndex < _poolSize; poolIndex++)
            {
                _pool.Add(MakeItem(false));
            }

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
        Projectile createdProjectile = Instantiate<Projectile>(_projectile, transform.position, transform.rotation);
        createdProjectile.gameObject.SetActive(isActive);
        createdProjectile.Pool = this;
        return createdProjectile;
    }

}
