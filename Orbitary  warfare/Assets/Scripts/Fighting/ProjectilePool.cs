using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private int _poolSize = 20;

    private List<Projectile> _pool = new List<Projectile>();

    private void Awake()
    {
        for (int poolIndex = 0; poolIndex < _poolSize; poolIndex++)
        {
            _pool.Add(AddToPool(false));
        }
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
         var newProjectile = AddToPool(true);
        _pool.Add(newProjectile);
        return newProjectile;
    }

    public void ReturnItem(Projectile returnedItem)
    {
        returnedItem.transform.position = transform.position;
        returnedItem.transform.rotation = transform.rotation;
        returnedItem.gameObject.SetActive(false);
    }

    private Projectile AddToPool(bool isActive)
    {
        Projectile createdProjectile = Instantiate<Projectile>(_projectile, transform.position, transform.rotation);
        createdProjectile.gameObject.SetActive(isActive);
        return createdProjectile;
    }

}
