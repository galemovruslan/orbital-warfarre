using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Upgrades/StockItem")]
public class StockItem : ScriptableObject 
{
    [SerializeField] private List<ScriptableObject> _stock = new List<ScriptableObject>();

    public ScriptableObject GetItem(int level)
    {
        int listIndex = level - 1;
        if (listIndex < 0 || listIndex >= _stock.Count)
        {
            return default(ScriptableObject);
        }
        return _stock[listIndex];
    }
}
