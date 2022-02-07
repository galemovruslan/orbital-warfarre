using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public int MoneyAmount { get => _moneyAmount; }
    public event Action<int> OnChange;

    [SerializeField] private EventAsset _onRewardGiven;

    private int _moneyAmount = 0;

    private void OnEnable()
    {
        _onRewardGiven.AddListener(Add);
    }

    private void OnDisable()
    {
        _onRewardGiven.RemoveListener(Add);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Add(50);
        }
    }

    public bool CheckAvailable(int value)
    {
        return _moneyAmount >= value;
    }

    public void Add(int amount)
    {
        _moneyAmount += amount;
        OnChange?.Invoke(_moneyAmount);
    }

    public void Remove(int amount)
    {
        if(!CheckAvailable(amount)) { return; }

        _moneyAmount -= amount;
        OnChange?.Invoke(_moneyAmount);
    }
}
