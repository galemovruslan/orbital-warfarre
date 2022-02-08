using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _accuracyText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _shipDestroyedText;

    [SerializeField] private EventAsset _pauseRequest;
    [SerializeField] private EventAsset _retryRequest;
    [SerializeField] private EventAsset _onGameOver;

    private void Awake()
    {
        _onGameOver.AddListener(GameOverHandler);
    }

    public void OnRetryButtonHandler()
    {
        _pauseRequest.Invoke((int)GamePauseRequestType.UnPause);
        gameObject.SetActive(false);
        _retryRequest.Invoke(0);
    }

    private void GameOverHandler(int code)
    {
        if (code != (int)GameOverCodes.Lose) { return; }

        _pauseRequest.Invoke((int)GamePauseRequestType.Pause);
        gameObject.SetActive(true);
    }

}

public enum GameOverCodes
{
    Lose,
    Win
}