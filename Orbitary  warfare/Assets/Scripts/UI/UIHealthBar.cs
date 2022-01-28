using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _bar;
    [SerializeField] private RuntimeRepository _playerRepository;

    private Health _playerHealth;

    private void Awake()
    {
         _playerHealth = _playerRepository.GetObjects()[0].GetComponent<Health>();
    }

    private void OnEnable()
    {
        _playerHealth.OnTakeDamage += UpdateBar;
    }

    private void OnDisable()
    {
        _playerHealth.OnTakeDamage -= UpdateBar;
    }


    private void UpdateBar(float currentHealth, float maxHealth)
    {
        _bar.localScale = new Vector3(currentHealth / maxHealth, 1);
    }

}
