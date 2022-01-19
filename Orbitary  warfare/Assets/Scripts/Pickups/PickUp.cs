
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private ProgressionItem _items;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Init(ProgressionItem stock, Sprite icon)
    {
        _items = stock;
        _renderer.sprite = icon;
        _rb.velocity = Random.insideUnitCircle.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUsed = TryPickup(collision.gameObject);

        if (isUsed)
        {
            Destroy(gameObject);
        }
    }

    private bool TryPickup(GameObject gameObject)
    {
        switch (_items.Type)
        {
            case ProgressionItem.ItemType.Shield:
                return TryPickUpShield(gameObject);

            case ProgressionItem.ItemType.Weapon:
                return TryPickUpWeapon(gameObject);

            default:
                return false;
        }
    }

    private bool TryPickUpShield(GameObject pickUpper)
    {
        return TryPickUp<Shield>(pickUpper);
    }

    private bool TryPickUpWeapon(GameObject pickUpper)
    {
        if (pickUpper.TryGetComponent<Shooter>(out var shooter))
        {
            var shooterWeapons = shooter.GetWeapons();
            if (shooterWeapons == null) { return false; }

            foreach (var weapon in shooterWeapons)
            {
                weapon.SetNewProgression(_items, level: 1);
            }
            return true;
        }
        return false;
    }

    private bool TryPickUp<T>(GameObject pickUpper) where T : ISwapProgression
    {
        if (_items != null &&
            pickUpper.TryGetComponent<T>(out var swapper)
            )
        {
            swapper.SetNewProgression(_items, level: 1);
            return true;
        }
        return false;
    }

}
