using UnityEngine;

[CreateAssetMenu(fileName ="New Shield", menuName ="Upgrades/Shield")]
public class ShieldItem : SwapableItem
{
    public float Durability { get => _durability; }
    public ShieldItemType Type { get => _type; }
    public GameObject Visuals { get => _visuals; }

    [SerializeField] private float _durability;
    [SerializeField] private ShieldItemType _type;
    [SerializeField] private GameObject _visuals;
}

public enum ShieldItemType
{
    Balistic,
    Energy
}

/*
 * ���������� ��� ������������� �� ���������� ����������� ��� ������������� �������� 
 * 
 */