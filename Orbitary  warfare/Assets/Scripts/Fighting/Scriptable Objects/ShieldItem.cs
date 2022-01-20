using UnityEngine;

[CreateAssetMenu(fileName ="New Shield", menuName ="Upgrades/Shield")]
public class ShieldItem : SwapableItem
{
    public float Durability { get => _durability; }
    public ShieldItemType Type { get => _type; }

    [SerializeField] private float _durability;
    [SerializeField] private ShieldItemType _type;

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