using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StockItem<T> : ScriptableObject where T : UpgradableItem
{
    public int MaxLevel => _stock.Count;

    [SerializeField] private List<T> _stock = new List<T>();

    public T GetItem(int level)
    {
        int listIndex = level - 1;
        if (listIndex < 0 || listIndex >= _stock.Count)
        {
            return default(T);
        }
        return _stock[listIndex];
    }
}
