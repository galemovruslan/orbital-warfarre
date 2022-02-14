using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private EventAsset _pauseRequest;
    [SerializeField] private EventAsset _retryRequest;
    [SerializeField] private EventAsset _onGameOver;
    [SerializeField] private EventAsset _timePlayedStatistics;
    [SerializeField] private GameOverCodes _gameOverCodeHandler;

    private const string _loseText = "You Lose";
    private const string _winText = "You Win!";


    private void Start()
    {
        _onGameOver.AddListener(GameOverHandler);
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        _onGameOver.RemoveListener(GameOverHandler);
    }

    public void OnRetryButtonHandler()
    {
        _pauseRequest.Invoke((int)GamePauseRequestType.UnPause);
        gameObject.SetActive(false);
        _retryRequest.Invoke(0);
    }

    private void GameOverHandler(int code)
    {
        if (code != (int)_gameOverCodeHandler) { return; }
        

        _pauseRequest.Invoke((int)GamePauseRequestType.Pause);
        gameObject.SetActive(true);
        _timePlayedStatistics.Invoke((int)Time.time * 100);
    }
}

public enum GameOverCodes
{
    Lose,
    Win
}