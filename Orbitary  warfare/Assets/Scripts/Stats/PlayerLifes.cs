using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private int _lives;
    [SerializeField] private EventAsset _onGameOver;
    //[SerializeField] private EventAsset _onPlayerChange;
    [SerializeField] private RuntimeRepository _playerRepo;
    [SerializeField] private Transform _playerParent;
    [SerializeField] private Transform _mainSpawn;
    [SerializeField] private Transform _replacePlawn;

    private Health _playerHealth;
    private GameObject _playerState;

    private void Awake()
    {
        GameObject player = Instantiate<GameObject>(_player, _mainSpawn.position, Quaternion.identity, _playerParent);

        for (int i = 1; i < _lives; i++)
        {
            player = Instantiate<GameObject>(_player, _replacePlawn.position, Quaternion.identity, _playerParent);
            
        }
    }

    private void Start()
    {
        _playerHealth = _playerRepo.GetObjects()[0].GetComponent<Health>();
        _playerHealth.OnDestroy += LostLive;
        //_onPlayerChange.AddListener(SavePlayer);
    }

    private void SavePlayer(int obj)
    {
        _playerState = _playerRepo.GetObjects()[0];
    }

    private void LostLive(GameObject gameObject)
    {
        _lives--;
        if(_lives < 0)
        {
            _onGameOver.Invoke((int) GameOverCodes.Lose);
        }
        else
        {
            _playerState = gameObject;
            RefreshPlayer();
            Instantiate<GameObject>(_playerState, Vector3.zero, Quaternion.identity, _playerParent);
        }
    }

    private void RefreshPlayer()
    {
        _playerHealth.Heal(10000);
        _playerState.GetComponentInChildren<Shield>().Heal(1000);
    }

}
