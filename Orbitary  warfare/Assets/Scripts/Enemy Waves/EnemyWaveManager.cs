using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] private EventAsset _requestRetry;
    [SerializeField] private EventAsset _OnGameFinish;
    [SerializeField] private WaveDescription[] _waveDescriptions;
    [SerializeField] private float _waveSpawnDelay;

    private EnemyWave _wave;
    private int _currentWaveNumber = -1;
    private int _maxWaveNumber;
    private float _spawnTimer;
    private bool _doesNeedSpawn = true;


    private void Awake()
    {
        _requestRetry.AddListener(OnRequestRetryHandler);
        _maxWaveNumber = _waveDescriptions.Length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnWave();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            WipeWave();
        }
        UpdateTimer();
    }
    private void OnRequestRetryHandler(int obj)
    {
        StartWithWave(_currentWaveNumber);
    }

    private void StartWithWave(int waveNumber)
    {
        _currentWaveNumber = waveNumber - 1;
        SpawnWave();
        ResetSpawnTimer();
    }

    private void UpdateTimer()
    {
        if (!_doesNeedSpawn) { return; }

        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _waveSpawnDelay)
        {
            SpawnWave();
            ResetSpawnTimer();
        }
    }

    private void ResetSpawnTimer()
    {
        _spawnTimer = 0;
        _doesNeedSpawn = false;
    }

    private void SpawnWave()
    {
        _currentWaveNumber++;
        if(_currentWaveNumber >= _maxWaveNumber)
        {
            _OnGameFinish.Invoke((int)GameOverCodes.Win);
            return;
        }
        var currentWave = _waveDescriptions[_currentWaveNumber];
        _wave = new EnemyWave(currentWave._content, currentWave._spawners);
        _wave.OnWaveCleared += OnWaveClearedHandle;

    }

    private void WipeWave()
    {
        _wave.ForceWipe();
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
