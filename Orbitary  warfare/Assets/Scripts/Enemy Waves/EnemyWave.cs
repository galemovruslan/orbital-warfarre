using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave
{
    public event Action OnWaveCleared;
    
    private WaveContent _content;
    private EnemySpawner[] _spawners;

    private int _spawnersCleared = 0;

    public EnemyWave(WaveContent content, EnemySpawner[] spawners)
    {
        _content = content;
        _spawners = spawners;

        foreach (var spawner in _spawners)
        {
            spawner.OnAllCleared += SpawnerCleared;
        }
        Spawn();
    }

    private void Spawn()
    {
        foreach (Description item in _content.GetDescriptions())
        {
            for (int amountCounter = 0; amountCounter < item.Amount; amountCounter++)
            {
                int randomIndex = UnityEngine.Random.Range(0, _spawners.Length);
                _spawners[randomIndex].Spawn(item.EnemyPrefab);
            }
        }

    }

    private void SpawnerCleared()
    {
        _spawnersCleared++;

        if(_spawnersCleared < _spawners.Length) { return; }

        foreach (var spawner in _spawners)
        {
            spawner.OnAllCleared -= SpawnerCleared;
        }

        OnWaveCleared?.Invoke();
    }
}
