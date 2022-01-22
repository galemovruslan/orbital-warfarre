using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IDamageable, IHaveShooterType, ISwapProgression
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

    [SerializeField] private ProgressionItem _currentStock;
    [SerializeField] private int _level;

    private ShieldItem _currentShield;

    private UpgradableVisuals _visuals;
    private CircleCollider2D _collider;
    private float _durability;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        Type = GetComponentInParent<Shooter>().Type;
        _visuals = GetComponentInChildren<UpgradableVisuals>();

        if (_level == 0)
        {
            Disable();
        }
        else
        {
            SetShield(_currentStock.GetItem(_level) as ShieldItem);
            Enable();
        }
    }

    private void OnValidate()
    {
        if (_currentStock != null &&
            _currentStock.Type != ProgressionItem.ItemType.Shield)
        {
            _currentStock = null;
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

    public void SetNewProgression(ProgressionItem newShield, int level)
    {
        if (_currentStock == newShield ||
            newShield.Type != ProgressionItem.ItemType.Shield
            )
        { return; }

        _currentStock = newShield;
        _level = level;
        SetShield(newShield.GetItem(_level) as ShieldItem);
    }

    public void LevelUp()
    {
        if (_level >= _currentStock.MaxLevel) { return; }
        _level++;
        SetShield(_currentStock.GetItem(_level) as ShieldItem);
    }

    private void SetShield(ShieldItem shield)
    {
        _currentShield = shield;
        Enable();
        UpdateVisuals();
    }


    private void Disable()
    {
        _collider.enabled = false;
        _visuals.DestroyVisuals();
    }

    private void Enable()
    {
        if (_currentShield == null) { return; }

        _collider.enabled = true;
        _durability = _currentShield.Durability;
    }

    private void UpdateVisuals()
    {
        if (_currentShield == null) { return; }

        _visuals.SetVisuals(_currentShield.Visuals);
    }
}
