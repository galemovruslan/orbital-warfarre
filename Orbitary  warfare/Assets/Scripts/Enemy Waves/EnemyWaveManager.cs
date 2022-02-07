using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{

    [SerializeField] private WaveDescription[] _waveDescriptions;
    [SerializeField] private float _waveSpawnDelay;

    private EnemyWave _wave;

    private int _currentWaveNumber = -1;
    private int _maxWaveNumber;

    private float _spawnDelayTimer;
    private bool _doesNeedSpawn = true;

    private void Awake()
    {
        _maxWaveNumber = _waveDescriptions.Length;
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (!_doesNeedSpawn) { return; }

        _spawnDelayTimer += Time.deltaTime;

        if (_spawnDelayTimer >= _waveSpawnDelay)
        {
            SpawnWave();
            _spawnDelayTimer = 0;
            _doesNeedSpawn = false;
        }
    }

    private void SpawnWave()
    {
        _currentWaveNumber++;
        if(_currentWaveNumber >= _maxWaveNumber)
        {
            Debug.Log("All waves complete");
            return;
        }
        var currentWave = _waveDescriptions[_currentWaveNumber];
        _wave = new EnemyWave(currentWave._content, currentWave._spawners);
        _wave.OnWaveCleared += OnWaveClearedHandle;

    }

    private void OnWaveClearedHandle()
    {
        _doesNeedSpawn = true;
        _wave.OnWaveCleared -= OnWaveClearedHandle;
    }


    [System.Serializable]
    private struct WaveDescription
    {
        public WaveContent _content;
        public EnemySpawner[] _spawners;
    }
}
