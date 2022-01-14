using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Default Stock")]
public class StockItem : ScriptableObject
{
    public UpgradeType Type = UpgradeType.None;
    [SerializeField] private List<ScriptableObject> _stock = new List<ScriptableObject>();

    public ScriptableObject GetItem(int level)
    {
        int listIndex = level - 1;
        if (listIndex < 0 || listIndex >= _stock.Count)
        {
            return null;
        }
        return _stock[listIndex];
    }
}
