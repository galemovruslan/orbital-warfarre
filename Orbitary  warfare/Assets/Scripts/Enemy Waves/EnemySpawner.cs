using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action OnAllCleared;
    public bool HaveAlive => _enemies.Count > 0;

    [SerializeField] private Transform _parentForSpawned;

    private List<Enemy> _enemies = new List<Enemy>();

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.OnDeath -= OnEnemyDeath;
        }
    }

    public void Spawn(Enemy enemy)
    {
        Enemy spawnedEnemy = Instantiate<Enemy>(enemy, transform.position, transform.rotation, _parentForSpawned);
        _enemies.Add(spawnedEnemy);
        spawnedEnemy.OnDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        _enemies.Remove(enemy);
        enemy.OnDeath -= OnEnemyDeath;

        if (!HaveAlive)
        {
            OnAllCleared?.Invoke();
        }
    }
}
