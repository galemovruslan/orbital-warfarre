using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Fighting/Weapon")]
public class WeaponItem : UpgradableItem
{
    public float TimeBetweenShots => _fireTime;
    public Color Color { get => _color; }
    public Sprite Sprite { get => _sprite; }
    public WeaponType Type { get => _type;  }

    [SerializeField] private float _fireTime = 1f;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;
    [SerializeField] private WeaponType _type;


}

public enum WeaponType
{
    Balistic,
    Energy
}