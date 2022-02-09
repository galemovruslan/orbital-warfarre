using System;
using UnityEngine;

public interface IDamageable 
{
    public event Action<float, float> OnTakeDamage;
    public event Action<GameObject> OnDeath;

    void TakeDamage(float amount);
}
