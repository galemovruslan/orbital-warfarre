using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float, float> OnHealthChanged;
    public event Action<GameObject> onDestroy;

    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        OnHealthChanged?.Invoke(_health, _maxHealth);

        if(_health <= 0)
        {
            onDestroy?.Invoke(this.gameObject);
            Destroy(gameObject);
        }
    }

}
