using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDeath;

    [SerializeField] private int _reward = 50;
    [SerializeField] private EventAsset _onRewardGiven;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDeath += GiveReward;
    }

    private void GiveReward(GameObject obj)
    {
        OnDeath?.Invoke(this);
        _onRewardGiven?.Invoke(_reward);
    }
}
