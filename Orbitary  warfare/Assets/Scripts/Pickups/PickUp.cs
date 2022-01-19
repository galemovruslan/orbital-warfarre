using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private WeaponStock _weaponItems;
    private ShieldStock _shieldItems;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Init(ShieldStock stock, Sprite icon)
    {
        _shieldItems = stock;
        _renderer.sprite = icon;
        _rb.velocity = Random.insideUnitCircle.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUsed = TryPickupShield(collision.gameObject);

        if (isUsed)
        {
            Destroy(gameObject);
        }
    }

    private bool TryPickupShield(GameObject pickUper)
    {
        if (_shieldItems != null &&
            pickUper.TryGetComponent<Shield>(out var shield)
            )
        {
            shield.SetNewProgression(_shieldItems as ShieldStock, level: 1);
            return true;
        }
        return false;
    }

}
