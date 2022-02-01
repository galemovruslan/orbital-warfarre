using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    [SerializeField] private PauseMenu _pauseMenu;

    private void Update()
    {
        MenuCommands();
    }

    private void MenuCommands()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.Togle();
        }
    }


}
