using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool IsShown => _isShown;

    [SerializeField] private EventAsset _pauseRequest;

    private bool _isShown = false;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Togle()
    {
        if (IsShown)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show()
    {
        _pauseRequest.Invoke((int)GamePauseRequestType.Pause);
        gameObject.SetActive(true);
        _isShown = true;
    }

    public void Hide()
    {
        _pauseRequest.Invoke((int)GamePauseRequestType.UnPause);
        gameObject.SetActive(false);
        _isShown = false;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
