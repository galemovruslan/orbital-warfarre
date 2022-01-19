using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Stock")]
public class ProgressionItem: ScriptableObject 
{

    public int MaxLevel => _stock.Count;

    public ItemType Type { get => _type; }

    [SerializeField] ItemType _type;
    [SerializeField] private List<UpgradableItem> _stock = new List<UpgradableItem>();

    public UpgradableItem GetItem(int level)
    {
        int listIndex = level - 1;
        if (listIndex < 0 || listIndex >= _stock.Count)
        {
            return default(UpgradableItem);
        }
        return _stock[listIndex];
    }
    public enum ItemType
    {
        Shield,
        Weapon
    }

}
