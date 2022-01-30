using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    [SerializeField] private EventAsset OnStateChange;

    private void OnEnable()
    {
        OnStateChange.AddListener(ChangeState);
    }

    private void OnDisable()
    {
        OnStateChange.RemoveListener(ChangeState);
    }

    private void ChangeState(int stateIdx)
    {
        switch (stateIdx) 
        {
            case -1:
                SceneChanger.Insance.RestartCurrent();
                break;
        }


    }

}
