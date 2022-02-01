using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static readonly int RestartCode = -1;
    public static readonly int QuitCode = -2;

    [SerializeField] private EventAsset _changeSceneRequest;


    private void OnEnable()
    {
        _changeSceneRequest.AddListener(ProcessRequest);
    }

    private void OnDisable()
    {
        _changeSceneRequest.RemoveListener(ProcessRequest);
    }

    private void ProcessRequest(int code)
    {
        if (code == RestartCode)
        {
            RestartCurrent();
        }
        else
        {
            Change(code);
        }

    }

    public void Change(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void RestartCurrent()
    {
        int currentId = SceneManager.GetActiveScene().buildIndex;
        Change(currentId);
    }

    public void QuitGame()
    {
        PopUpWindow.Instance.Show("Quit Game?", 
            () => Application.Quit(), 
            () => { });
    }
}


public enum GameStateCommandType
{
    Restart,
    Pause
}