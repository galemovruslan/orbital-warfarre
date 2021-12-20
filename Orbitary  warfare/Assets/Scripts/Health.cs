using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log($"{name} took {amount} of damage. {_health} HP left");
        _health -= amount;

        if(_health < 0)
        {
            Destroy(gameObject);
        }
    }

}
