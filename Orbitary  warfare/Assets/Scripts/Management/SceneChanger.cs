using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public static SceneChanger Insance = null;

    private void Awake()
    {
        if(Insance == null)
        {
            Insance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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

}
