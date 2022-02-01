using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EventAsset OnStateChange;

    Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnDestroy += PlayerDestroy;
    }

    private void PlayerDestroy(GameObject gameObject)
    {
        OnStateChange.Invoke(SceneChanger.RestartCode);
    }

}
