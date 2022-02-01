using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public bool IsPaused { get { return _isPaused; } }

    [SerializeField] private EventAsset _pauseRequest;

    private bool _isPaused = false;

    private void OnEnable()
    {
        _pauseRequest.AddListener(ProcessRequest);
    }

    private void OnDisable()
    {
        _pauseRequest.RemoveListener(ProcessRequest);
    }

    private void ProcessRequest(int code)
    {
        GamePauseRequestType codeType = (GamePauseRequestType)code;
        switch (codeType)
        {
            case GamePauseRequestType.Pause:
                Pause();
                break;
            case GamePauseRequestType.UnPause:
                UnPause();
                break;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        _isPaused = false;
    }
}

public enum GamePauseRequestType
{
    Pause,
    UnPause
}