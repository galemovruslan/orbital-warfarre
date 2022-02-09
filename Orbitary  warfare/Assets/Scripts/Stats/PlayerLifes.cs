using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private EventAsset _onGameOver;
    [SerializeField] private EventAsset _onPlayerChange;
    [SerializeField] private RuntimeRepository _playerRepo;
    [SerializeField] private int _maxLives;
    [SerializeField] private Transform _playerParent;
    [SerializeField] private Transform _mainSpawn;
    [SerializeField] private Transform _copyLocation;

    private Health _playerHealth;
    private Player _playerCopy;
    private Player _activePlayer;
    private int _lives;

    private void Awake()
    {
        _lives = _maxLives;
        _activePlayer = Instantiate<Player>(_playerPrefab, _mainSpawn.position, Quaternion.identity, _playerParent);
        _onPlayerChange.AddListener(OnSavePlayerRequired);
    }

    private void Start()
    {
        SavePlayer();
        _playerHealth = _activePlayer.Health;
        _playerHealth.OnDeath += LostLive;
    }

    private void SavePlayer()
    {
        if (_playerCopy != null)
        {
            Destroy(_playerCopy);
        }
        MakePlayerCopy();
    }

    private void LostLive(GameObject gameObject)
    {
        _lives--;
        if(_lives <= 0)
        {
            _onGameOver.Invoke((int) GameOverCodes.Lose);
            _lives = _maxLives;
        }
        MakePlayerCopy();
        RespawnPlayer();

    }

    private void RespawnPlayer()
    {
        _activePlayer = Instantiate<Player>(_playerCopy, _mainSpawn.position, Quaternion.identity, _playerParent);
        _activePlayer.gameObject.SetActive(true);
        _playerHealth = _activePlayer.GetComponent<Health>();
        _playerHealth.OnDeath += LostLive;
        _activePlayer.Bank.Add(_playerCopy.Bank.MoneyAmount);
    }

    private void OnSavePlayerRequired(int idx)
    {
        SavePlayer();
    }

    private void MakePlayerCopy()
    {
        _playerCopy = Instantiate(_activePlayer, _copyLocation.position, Quaternion.identity);
        _playerCopy.gameObject.SetActive(false);
        _playerCopy.Health.Heal(1000);
        _playerCopy.Shield.Heal(1000);
        _playerCopy.Bank.Add(_activePlayer.Bank.MoneyAmount);
    }

}
