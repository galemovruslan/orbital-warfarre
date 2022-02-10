using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _bar;
    [SerializeField] private RuntimeRepository _playerRepository;

    private Health _playerHealth;

    private void Start()
    {
        OnRepositoryChange();

        if (_playerHealth == null) { return; }

        _playerHealth.OnTakeDamage += UpdateBar;
        _playerRepository.OnRemove += OnRepositoryChange;
    }

    private void OnDisable()
    {
        _playerRepository.OnRemove -= OnRepositoryChange;

        if (_playerHealth == null) { return; }

        _playerHealth.OnTakeDamage -= UpdateBar;
    }


    private void UpdateBar(float currentHealth, float maxHealth)
    {
        _bar.localScale = new Vector3(currentHealth / maxHealth, 1);
    }

    private void OnRepositoryChange()
    {
        Health newHealth = _playerRepository.GetObjects()[0].GetComponent<Health>();
        if(_playerHealth == newHealth) { return; }

        _playerHealth = newHealth;
        _playerHealth.OnTakeDamage += UpdateBar;
        _bar.localScale = Vector3.one;
    }
}
