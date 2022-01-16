using UnityEngine;

[CreateAssetMenu(fileName ="New Shield", menuName ="Upgrades/Shield")]
public class ShieldItem : UpgradableItem
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _color;
    [SerializeField] private float _durability;
    [SerializeField] private ShieldItemType _type;

    public Sprite Sprite { get => _sprite; }
    public float Durability { get => _durability; }
    public ShieldItemType Type { get => _type; }
    public Color ShieldColor { get => _color; }
}

public enum ShieldItemType
{
    Balistic,
    Energy
}

/*
 * переделать код отвестсвенный за визуальное отображение под использование префабов 
 * 
 */