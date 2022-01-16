using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IDamageable, IHaveShooterType
{
    public event Action<float, float> OnTakeDamage;
    public event Action<GameObject> OnDestroy;

    public ShooterType Type { get; private set; }
    public int Level
    {
        get
        {
            if (_currentShield == null)
            {
                return 0;
            }
            else
            {
                return _level;
            }
        }
    }
    [SerializeField] private ShieldStock _currentStock;
    [SerializeField] private int _level;

    private ShieldItem _currentShield;

    private SpriteRenderer _renderer;
    private CircleCollider2D _collider;
    private float _durability;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
        Type = GetComponentInParent<Shooter>().Type;


        if (_level == 0)
        {
            Disable();
        }
        else
        {
            SetShield(_currentStock.GetItem(_level));
            Enable();
        }
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

    public void SetNewProgression(ShieldStock newShield, int level)
    {
        _currentStock = newShield;
        _level = level;
        SetShield(newShield.GetItem(_level));
    }

    public void LevelUp()
    {
        if (_level >= _currentStock.MaxLevel)
        {
            return;
        }
        _level++;
        SetShield(_currentStock.GetItem(_level));
    }

    private void SetShield(ShieldItem shield)
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
        _renderer.color = _currentShield.ShieldColor;
        _durability = _currentShield.Durability;
    }
}
