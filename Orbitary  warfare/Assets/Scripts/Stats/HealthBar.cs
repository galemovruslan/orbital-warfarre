using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _bar;

    private Health _health;

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
    }

    private void OnEnable() => _health.OnTakeDamage += UpdateBar;

    private void OnDisable() => _health.OnTakeDamage -= UpdateBar;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -_health.transform.rotation.z);
    }

    private void UpdateBar(float currentHealth, float maxHealth)
    {
        _bar.localScale = new Vector3(currentHealth / maxHealth, 1);
    }

}
