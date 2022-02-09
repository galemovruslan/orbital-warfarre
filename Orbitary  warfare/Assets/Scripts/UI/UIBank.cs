using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBank : MonoBehaviour
{
    [SerializeField] private RuntimeRepository _playerRepository;
    [SerializeField] private TextMeshProUGUI _amountText;

    private Bank _bank;

    private void Start()
    {
        OnRepositoryChange();
        _playerRepository.OnRemove += OnRepositoryChange ;
        UpdateUI(_bank.MoneyAmount);
    }

    private void OnDisable()
    {
        if (_bank == null) { return; }
        _bank.OnChange -= UpdateUI;
    }

    private void UpdateUI(int amount)
    {
        _amountText.text = amount.ToString();
    }

    private void OnRepositoryChange()
    {
        _bank = _playerRepository.GetObjects()[0].GetComponent<Bank>();
        _bank.OnChange += UpdateUI;
    }
}
