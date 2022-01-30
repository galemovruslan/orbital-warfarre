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
        _playerHealth = _playerRepository.GetObjects()[0].GetComponent<Health>();

        if (_playerHealth == null) { return; }

        _playerHealth.OnTakeDamage += UpdateBar;
    }

    private void OnDisable()
    {
        if (_playerHealth == null) { return; }

        _playerHealth.OnTakeDamage -= UpdateBar;
    }


    private void UpdateBar(float currentHealth, float maxHealth)
    {
        _bar.localScale = new Vector3(currentHealth / maxHealth, 1);
    }

}
