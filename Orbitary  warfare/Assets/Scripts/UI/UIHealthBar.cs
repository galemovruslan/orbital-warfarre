using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _healthBar;
    [SerializeField] private RectTransform _shieldBar;
    [SerializeField] private RuntimeRepository _playerRepository;

    private Health _playerHealth;
    private Shield _playerShield;

    private void Start()
    {
        OnRepositoryChange();

        _playerRepository.OnRemove += OnRepositoryChange;
    }

    private void OnDisable()
    {
        _playerRepository.OnRemove -= OnRepositoryChange;

        if (_playerHealth == null) { return; }

        _playerHealth.OnTakeDamage -= UpdateHealthBar;
        _playerShield.OnTakeDamage -= UpdateShieldBar;
    }

    private void OnRepositoryChange()
    {
        _playerHealth = _playerRepository.GetObjects()[0].GetComponent<Health>();
        _playerHealth.OnTakeDamage += UpdateHealthBar;
        _healthBar.localScale = Vector3.one;

        _playerShield = _playerRepository.GetObjects()[0].GetComponentInChildren<Shield>();
        _playerShield.OnTakeDamage += UpdateShieldBar;
        _shieldBar.localScale = new Vector3(Mathf.Clamp01(_playerShield.Durability), 1, 1);
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        _healthBar.localScale = new Vector3(currentHealth / maxHealth, 1);
    }

    private void UpdateShieldBar(float currendDurability, float maxDurability)
    {
        _shieldBar.localScale = new Vector3(currendDurability / maxDurability, 1);
    }
}
