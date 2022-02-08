using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action<float, float> OnTakeDamage;
    public event Action<GameObject> OnDestroy;

    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Heal(float amount)
    {
        _health = Mathf.Min(_health + amount, _maxHealth);
    }

    public void TakeDamage(float amount)
    {
        _health = Mathf.Max(0, _health - amount);
        OnTakeDamage?.Invoke(_health, _maxHealth);

        if(_health <= 0)
        {
            OnDestroy?.Invoke(this.gameObject);
            Destroy(gameObject);
        }
    }

}
