using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IDamageable
{
    public event Action<float, float> OnTakeDamage;
    public event Action<GameObject> OnDestroy;

    public int Level {
        get
        {
            if (_currentShield == null)
            {
                return 0;
            }
            else
            {
                return _currentShield.Level;
            }
        } 
    }

    [SerializeField] private ShieldItem _currentShield;

    private SpriteRenderer _renderer;
    private CircleCollider2D _collider;
    private float _durability;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();

        Enable();
    }


    public void TakeDamage(float amount)
    {
        if (_currentShield == null)
        {
            return;
        }

        _durability -= amount;
        OnTakeDamage?.Invoke(_durability, _currentShield.Durability);
        if (_durability <= 0)
        {
            Disable();
            OnDestroy?.Invoke(this.gameObject);
        }
    }

    public void SetShield(ShieldItem shield)
    {
        _currentShield = shield;
        Enable();
    }

    private void Disable()
    {
        _collider.enabled = false;
        _renderer.sprite = null;
    }

    private void Enable()
    {
        if (_currentShield == null)
        {
            return;
        }
        _collider.enabled = true;
        _renderer.sprite = _currentShield.Sprite;
        _durability = _currentShield.Durability;
    }
}
