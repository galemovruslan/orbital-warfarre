
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private ProgressionItem _items;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
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

    private bool TryPickup(GameObject pickUpper)
    {
        switch (_items.Type)
        {
            case ProgressionItem.ItemType.Shield:
                return TryPickUpShield(pickUpper);

            case ProgressionItem.ItemType.Weapon:
                return TryPickUpWeapon(pickUpper);

            case ProgressionItem.ItemType.Projectile:
                return TryPickUpProjectile(pickUpper);

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
            return shooter.SetWeaponProgression(_items);
        }
        return false;
    }

    private bool TryPickUpProjectile(GameObject pickUpper)
    {
        if (pickUpper.TryGetComponent<Shooter>(out var shooter))
        {
            return shooter.SetProjectileProgression(_items);
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
